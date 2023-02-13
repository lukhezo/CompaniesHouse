using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Response
{
    public class SearchLinks
    {
        public string company_profile { get; set; }
    }

    public class SearchRegisteredOfficeAddress
    {
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string locality { get; set; }
        public string postal_code { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class TopHit
    {
        public string company_name { get; set; }
        public string company_number { get; set; }
        public string company_status { get; set; }
        public string company_type { get; set; }
        public string kind { get; set; }
        public SearchLinks links { get; set; }
        public string date_of_cessation { get; set; }
        public string date_of_creation { get; set; }
        public RegisteredOfficeAddress registered_office_address { get; set; }
        public List<string> sic_codes { get; set; }
    }

    public class SearchItem
    {
        public string company_name { get; set; }
        public string company_number { get; set; }
        public string company_status { get; set; }
        public string company_type { get; set; }
        public string kind { get; set; }
        public SearchLinks links { get; set; }
        public string date_of_cessation { get; set; }
        public string date_of_creation { get; set; }
        public SearchRegisteredOfficeAddress registered_office_address { get; set; }
        public List<string> sic_codes { get; set; }
    }

    public class SearchResponse
    {
        public string etag { get; set; }
        public TopHit top_hit { get; set; }
        public List<SearchItem> items { get; set; }
        public string kind { get; set; }
        public int hits { get; set; }
    }

}
