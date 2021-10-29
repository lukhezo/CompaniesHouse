namespace CompaniesHouse.Response
{
    public class RegisteredAddressResponse
    {
        public string etag { get; set; }
        public string kind { get; set; }
        public Links links { get; set; }
        public string address_line_1 { get; set; }
        public string address_line_2 { get; set; }
        public string country { get; set; }
        public string locality { get; set; }
        public string postal_code { get; set; }
    } 
}
