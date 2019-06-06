using System.Collections.Generic;

namespace SelfServiceMachine.Entity.SResponse
{
    public class FY005
    {
        public string ckc618 { get; set; }
        public string akc264 { get; set; }
        public decimal akb068 { get; set; }
        public decimal akb066 { get; set; }
        public decimal akb067 { get; set; }
        public decimal aae240 { get; set; }
        public List<outputlistfy0051> outputlist1 { get; set; }
        public List<outputlistfy0052> outputlist2 { get; set; }
        public List<outputlistfy0053> outputlist3 { get; set; }
    }

    public class outputlistfy0051
    {
        public string aka111 { get; set; }
        public decimal bka058 { get; set; }
    }

    public class outputlistfy0052
    {
        public string aaa036 { get; set; }
        public decimal aae019 { get; set; }
    }

    public class outputlistfy0053
    {
        public string aka037 { get; set; }
        public decimal bke264 { get; set; }
    }
}
