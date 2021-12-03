using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Response
{

    public class RegistersItem
    {
        public string moved_on { get; set; }
        public string register_moved_to { get; set; }
    }

    public class Members
    {
        public string register_type { get; set; }
        public List<RegistersItem> items { get; set; }
    }

    public class Registers
    {
        public Members members { get; set; }
    }

    public class RegistersLinks
    {
        public string self { get; set; }
    }

    public class RegistersResponse
    {
        public Registers registers { get; set; }
        public string kind { get; set; }
        public RegistersLinks links { get; set; }
    }

}
