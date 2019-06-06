using System.Collections.Generic;

namespace SelfServiceMachine.Entity.SResponse
{
    public class MZ002
    {
        public string ckc618 { get; set; }
        public string akc264 { get; set; }
        public decimal akb068 { get; set; }
        public decimal akb066 { get; set; }
        public decimal akb067 { get; set; }
        public decimal aae240 { get; set; }
        public List<outputlistmz002> outputlist { get; set; }
        public List<outputlistmz0022> outputlist2 { get; set; }
    }

    public class outputlistmz002
    {
        public string aaa036 { get; set; }
        public decimal aae019 { get; set; }
    }

    public class outputlistmz0022
    {
        public string aka037 { get; set; }
        public decimal bke264 { get; set; }
    }
}
