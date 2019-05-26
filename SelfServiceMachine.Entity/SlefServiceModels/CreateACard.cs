using System.Xml.Serialization;

namespace SelfServiceMachine.Entity.SlefServiceModels
{
    [XmlRoot("request")]
    public class CreateACard
    {
        public string branchCode { get; set; }
        public string patType { get; set; }
        public string patName { get; set; }
        public string patSex { get; set; }
        public int patAge { get; set; }
        public string patBirth { get; set; }
        public string patAddress { get; set; }
        public string patMobile { get; set; }
        public string patYbkh { get; set; }
        public string patDnh { get; set; }
        public string patYbjbmc { get; set; }
        public string patCblx { get; set; }
        public int patIdType { get; set; }
        public string patIdNo { get; set; }
        public string guardName { get; set; }
        public string guardIdType { get; set; }
        public string guardIdNo { get; set; }
    }
}
