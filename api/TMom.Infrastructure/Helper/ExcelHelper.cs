using ExcelDataReader;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Core.Models;
using Magicodes.ExporterAndImporter.Excel;
using Magicodes.ExporterAndImporter.Excel.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Data;
using System.Text;

namespace TMom.Infrastructure.Helper
{
    /// <summary>
    /// Excel帮助类
    /// </summary>
    public static class ExcelHelper
    {
        private static IWebHostEnvironment _webHostEnvironment => AutofacContainer.Resolve<IWebHostEnvironment>();

        /// <summary>
        /// 根据文件名称获取文件流
        /// </summary>
        /// <param name="fileName">wwwroot下面的文件路径及名称, eg: 计划导入模板.xlsx 或者 Templates/计划导入模板.xlsx</param>
        /// <returns></returns>
        public static Stream GetFileStreamByName(string fileName)
        {
            string path = $"{_webHostEnvironment.ContentRootPath}/wwwroot/{fileName}";
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            byte[] vs = new byte[fs.Length];
            while (true)
            {
                int r = fs.Read(vs, 0, vs.Length);
                string s = Encoding.UTF8.GetString(vs, 0, r);
                if (r == 0)
                {
                    fs.Close();
                    break;
                }
            }
            Stream stream = new MemoryStream(vs);
            return stream;
        }

        /// <summary>
        /// 渲染Excel数据内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="headers">表头</param>
        /// <param name="dataList">数据列表</param>
        /// <param name="sheetName"></param>
        /// <returns>Excel数据字节流</returns>
        public static byte[] RenderExcelData<T>(List<string> headers, List<T> dataList, string sheetName = "Sheet1") where T : class
        {
            var table = new DataTable();
            var dataCols = headers.Cast<DataColumn>().ToArray();
            table.Columns.AddRange(dataCols);

            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add(sheetName);
                ws.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                var index = 1;
                foreach (var item in dataCols)
                {
                    ws.Cells[1, index].Style.Font.Bold = true;
                    ws.Cells[1, index++].Value = item;
                }

                ws.Cells["A2"].LoadFromCollection(dataList)?.AutoFitColumns();
                var rows = dataList.Count + 1;
                var cols = dataCols.Count();
                ws.Cells[1, 1, rows, cols].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[1, 1, rows, cols].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                ws.Cells[1, 1, rows, cols].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[1, 1, rows, cols].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                var by = p.GetAsByteArray();
                return by;
            }
        }

        /// <summary>
        /// 读取Excel
        /// </summary>
        /// <param name="file"></param>
        /// <param name="useHeaderRow">首行是否表头</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable ReadExcel(IFormFile file, bool useHeaderRow = true)
        {
            DataTable dt = new DataTable();
            try
            {
                MemoryStream ms = new MemoryStream();
                file.OpenReadStream().CopyTo(ms);
                byte[] data = ms.ToArray();
                Stream stream = new MemoryStream(data);
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var dataSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = useHeaderRow,
                    }
                });
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 根据文件流读取Excel
        /// </summary>
        /// <param name="stream">文件流</param>
        /// <param name="useHeaderRow">首行是否表头</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DataTable ReadExcelByStream(Stream stream, bool useHeaderRow = true)
        {
            DataTable dt = new DataTable();
            try
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                var dataSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = useHeaderRow,
                    }
                });
                if (dataSet != null && dataSet.Tables.Count > 0)
                {
                    dt = dataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// 获取导入结果, 验证有误时会抛出错误
        /// </summary>
        /// <typeparam name="T">配置字段导入验证特性的dto</typeparam>
        /// <param name="file">文件</param>
        /// <returns>Data即为验证无误的结果</returns>
        public static ImportResult<T> GetImportResult<T>(IFormFile file) where T : class, new()
        {
            MemoryStream ms = new MemoryStream();
            file.OpenReadStream().CopyTo(ms);
            byte[] data = ms.ToArray();
            Stream stream = new MemoryStream(data);
            IImporter importer = new ExcelImporter();
            var result = importer.Import<T>(stream).Result;
            if (result == null) return new ImportResult<T>();
            if (result.Exception != null) throw result.Exception;
            if (result.RowErrors.Count > 0)
            {
                string errors = JsonHelper.ObjToJson(result.RowErrors);
                throw new Exception(errors);
            }
            return result;
        }

        /// <summary>
        /// 获取导入模板
        /// </summary>
        /// <typeparam name="T">配置字段导入验证特性的dto</typeparam>
        /// <param name="sheetName">模板名称</param>
        /// <returns></returns>
        public static XlsxFileResult GetTemplate<T>(string sheetName) where T : class, new()
        {
            IImporter importer = new ExcelImporter();
            var result = importer.GenerateTemplateBytes<T>().Result;
            var stream = new MemoryStream(result);
            return new XlsxFileResult(stream, fileDownloadName: sheetName);
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <typeparam name="T">可以是dto, 配置一些导出特性</typeparam>
        /// <param name="sheetName">导出表格名称</param>
        /// <param name="dataList">数据源</param>
        /// <returns></returns>
        public static async Task<XlsxFileResult> ExportAsync<T>(string sheetName, ICollection<T> dataList) where T : class, new()
        {
            IExporter exporter = new ExcelExporter();
            var result = await exporter.ExportAsByteArray(dataList);
            var stream = new MemoryStream(result);
            return new XlsxFileResult(stream, fileDownloadName: sheetName);
        }

        /// <summary>
        /// 导出数据
        /// </summary>
        /// <typeparam name="T">可以是dto, 配置一些导出特性</typeparam>
        /// <param name="sheetName">导出表格名称</param>
        /// <param name="dataList">数据源</param>
        /// <returns></returns>
        public static XlsxFileResult<T> Export<T>(string sheetName, ICollection<T> dataList) where T : class, new()
        {
            return new XlsxFileResult<T>(dataList, sheetName);
        }
    }
}