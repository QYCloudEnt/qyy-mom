using System.Drawing.Printing;

namespace TMom.Client.Helper
{
    /// <summary>
    /// 打印帮助类(只能用在本地)
    /// </summary>
    public static class PrintHelper
    {
        /// <summary>
        /// 获取本地所有打印机名称(第一个为默认打印机)
        /// </summary>
        /// <returns></returns>
        public static List<string> GetLocalPrinters()
        {
            List<string> result = new List<string>();
            result.Add(GetDefaultPrint());

            foreach (string printName in PrinterSettings.InstalledPrinters)
            {
                if (!result.Contains(printName))
                {
                    result.Add(printName);
                }
            }
            return result;
        }

        /// <summary>
        /// 获取本地默认打印机名称
        /// </summary>
        /// <returns></returns>
        public static string GetDefaultPrint()
        {
            string name = new PrintDocument().PrinterSettings.PrinterName;
            return name;
        }
    }
}