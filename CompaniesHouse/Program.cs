using CompaniesHouse.Response;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesHouse
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        /// <summary>
        /// Make sure you log into the companies ouse website and obtain an API key for the
        /// LIVE environment. You will need to enter is below where is says "YOURAPIKEYHERE"
        /// </summary>
        /// <returns></returns>
        private static async Task ProcessRepositories()
        {
            HttpClient client = new HttpClient { BaseAddress = new Uri("https://api.company-information.service.gov.uk/") };
     
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes("YOURAPIKEYHERE")));
 
            string companyNumber = "07476462";

            // Registered Office Address Query
            var officeAddress = $"company/{companyNumber}/registered-office-address";
            var response = await client.GetStringAsync(officeAddress);
            var rar = JsonConvert.DeserializeObject<RegisteredAddressResponse>(response);

            //Just for Viewing in Console Screen
            string formatedRegisteredAddressResponse = JsonConvert.SerializeObject(rar, Formatting.Indented);
            Console.Write(formatedRegisteredAddressResponse);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // Company Profile Query
            var companyProfile = $"company/{companyNumber}";
            var companyProfileResponse = await client.GetStringAsync(companyProfile);
            var apr = JsonConvert.DeserializeObject<CompanyProfileReponse>(companyProfileResponse);

            //Just for Viewing in Console Screen
            string formatedCompanyProfileReponse = JsonConvert.SerializeObject(apr, Formatting.Indented);
            Console.Write(formatedCompanyProfileReponse);


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.ReadKey();    
        }
    }


}
