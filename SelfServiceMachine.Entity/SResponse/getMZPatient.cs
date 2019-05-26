namespace SelfServiceMachine.Entity.SResponse
{
    public class getMZPatient
    {
        public int resultCode { get; set; }
        public string resultMessage { get; set; }
        public int patType { get; set; }
        public string patName { get; set; }
        public string patSex { get; set; }
        public string patBirth { get; set; }
        public string patAddress { get; set; }
        public string patMobile { get; set; }
        public int patIdType { get; set; }
        public string patIdNo { get; set; }
        public int patCardType { get; set; }
        public string patCardNo { get; set; }
        public bool hasMedicare { get; set; }
    }
}
