namespace CompaniesHouse.Response
{
    public class AppointmentsResponse
    {
        public Links links { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
        public string appointed_on { get; set; }
        public string officer_role { get; set; }
    }


}
