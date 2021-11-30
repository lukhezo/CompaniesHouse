using System.Collections.Generic;
namespace CompaniesHouse.Response
{
    public class EstablishmentsResponse
    {
        public string etag { get; set; }
        public Links links { get; set; }
        public string kind { get; set; }
        public List<object> items { get; set; }
    }
}
