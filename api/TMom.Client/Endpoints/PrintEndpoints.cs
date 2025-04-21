using TMom.Client.Helper;
using System.Text.Json.Serialization;

namespace TMom.Client.Endpoints
{
    public static class PrintEndpoints
    {
        public static void MapPrintEndpoints(this IEndpointRouteBuilder builder)
        {
            var endpoint = builder.MapGroup("/Print");

            endpoint.MapGet("/GetLocalPrinter", GetLocalDefaultPrinter);
            endpoint.MapGet("/GetLocalPrinters", GetLocalPrinters);
        }

        /// <summary>
        /// 获取本地默认打印机名称
        /// </summary>
        /// <returns></returns>
        public static MessageModel<string> GetLocalDefaultPrinter()
        {
            var defaultPrinter = PrintHelper.GetDefaultPrint();
            return ResponseHelper.Success(defaultPrinter);
        }

        /// <summary>
        /// 获取本地所有打印机
        /// </summary>
        /// <returns></returns>
        public static MessageModel<List<string>> GetLocalPrinters()
        {
            var list = PrintHelper.GetLocalPrinters();
            return ResponseHelper.Success(list);
        }
    }

    [JsonSerializable(typeof(MessageModel<Dictionary<string, string>>))]
    [JsonSerializable(typeof(MessageModel<string>))]
    [JsonSerializable(typeof(MessageModel<List<string>>))]
    [JsonSerializable(typeof(MessageModel<bool>))]
    internal partial class PrintJsonSerializerContext : JsonSerializerContext
    {
    }
}