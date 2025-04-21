using SapNwRfc;

namespace TMom.Application.Dto
{
    public class SapWorkOrderParam
    {
        [SapName("P_WERKS")]
        public string FactoryCode { get; set; }

        [SapName("P_LAEDA")]
        public string UpdateTime { get; set; }

        [SapName("P_TIMES")]
        public string UpdateTimeSpan { get; set; }

        [SapName("P_AUFNR")]
        public SapWorkOrderCode[] Codes { get; set; } = new SapWorkOrderCode[] { };
    }

    public class SapWorkOrderCode
    {
        [SapName("AUFNR")]
        public string Code { get; set; }
    }
}