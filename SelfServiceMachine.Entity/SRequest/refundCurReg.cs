namespace SelfServiceMachine.Entity.SRequest
{
    public class refundCurReg
    {
        public string branchCode { get; set; }
        public string hisOrdNum { get; set; }
        public string psOrdNum { get; set; }
        public string psRefOrdNum { get; set; }
        public string agtRefOrdNum { get; set; }
        public string refundMode { get; set; }
        public decimal refundAmout { get; set; }
        public string refundTime { get; set; }
        public string refundReason { get; set; }
    }
}
