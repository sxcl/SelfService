using System.Collections.Generic;

namespace SelfServiceMachine.Entity.SResponse
{
    public class FY004
    {
        public decimal akc264 { get; set; }
        public decimal akb068 { get; set; }
        public decimal akb066 { get; set; }
        public decimal akb067 { get; set; }
        public decimal aae240 { get; set; }
        public List<outputlistfy0041> outputlist1 { get; set; }
        public List<outputlistfy0042> outputlist2 { get; set; }
        public List<outputlistfy0043> outputlist3 { get; set; }
    }

    public class outputlistfy0041
    {
        public string aka111 { get; set; }
        public decimal bka058 { get; set; }
    }

    public class outputlistfy0042
    {
        public string aaa036 { get; set; }
        public decimal aae019 { get; set; }
    }

    public class outputlistfy0043
    {
        public string aka037 { get; set; }
        public decimal bke264 { get; set; }
    }
}
