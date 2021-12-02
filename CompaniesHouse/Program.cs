﻿using CompaniesHouse.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesHouse
{
    class Program
    {
        public static string ApiKey { get; set; } = "YOURAPIKEYHERE";
        public static Uri BaseAddress { get; set; } = new Uri("https://api.company-information.service.gov.uk/");

        static async Task Main(string[] args)
        {
            bool isNumeric;
            string companyNumber;
            do
            {
                Console.Write("Please enter a company number:");
                companyNumber = Console.ReadLine().Trim();
                isNumeric = int.TryParse(companyNumber, out _);
                Console.WriteLine();
            } while (!isNumeric);

            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;

            do
            {
                cki = Console.ReadKey();     
                if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
                if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
                if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
               
                if(cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N)
                {
                    Console.Clear();
                    Console.WriteLine("View API responses in console screen or web browser (Y/N):");
                    Console.WriteLine($"You entered {cki.Key}");
                }

            } while (cki.Key != ConsoleKey.Y && cki.Key != ConsoleKey.N);
        

        Console.WriteLine();

            int choice = -1;

            while (choice != 0)
            {
                Console.WriteLine("Please choose one of the following options:");
                Console.WriteLine();
                Console.WriteLine("1. Registered Address");
                Console.WriteLine("2. Company Profile");
                Console.WriteLine("3. Officers"); 
                Console.WriteLine("4. UK Establishments");
                Console.WriteLine("5. Exit");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
                catch (System.FormatException)
                {
                    // Set to invalid value
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        await RegisteredOfficeAddress(companyNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 2:
                        await CompanyProfile(companyNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 3:
                        await Officers(companyNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 4:
                        await Establishments(companyNumber, cki.Key == ConsoleKey.Y);
                        break;
                    case 5:
                        // Exit the program
                        Console.WriteLine("Goodbye...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
            }  
        }

        /// <summary>
        /// Make sure you log into the companies ouse website and obtain an API key for the
        /// LIVE environment. You will need to enter is below where is says "YOURAPIKEYHERE"
        /// </summary>
        /// <returns></returns>
        private static async Task RegisteredOfficeAddress(string companyNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey)));

            // Registered Office Address Query
            var query = $"company/{companyNumber}/registered-office-address";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<RegisteredAddressResponse>(response);

            //Just for Viewing in Console Screen
            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task CompanyProfile(string companyNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey)));
            
            // Company Profile Query
            var query = $"company/{companyNumber}";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<CompanyProfileReponse>(response);
            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);
        
            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }

            //if(obj.company_status == "active")
            //{
            //    //Just for Viewing in Console Screen
            //    string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);
            //    Console.WriteLine(formattedReponse);
            //    //OpenInWebBrowser(formattedReponse);
            //}
            //else
            //{
            //    Console.WriteLine($"{companyNumber} is no longer active");
            //}

        }

        private static async Task Officers(string companyNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey)));

            // Company Profile Query
            var query = $"company/{companyNumber}/officers";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<OfficersResponse>(response);
            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);
        
            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        private static async Task Establishments(string companyNumber, bool isFormated)
        {
            HttpClient client = new HttpClient { BaseAddress = BaseAddress };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(ApiKey)));

            // Company Profile Query
            var query = $"company/{companyNumber}/uk-establishments";
            var response = await client.GetStringAsync(query);
            var obj = JsonConvert.DeserializeObject<EstablishmentsResponse>(response);
            string formattedReponse = JsonConvert.SerializeObject(obj, Formatting.Indented);
          
            if (isFormated)
            {
                Console.WriteLine(formattedReponse);
            }
            else
            {
                OpenInWebBrowser(formattedReponse);
            }
        }

        public static void OpenInWebBrowser(string formattedReponse)
        {
            string file = Path.GetTempPath() + Guid.NewGuid().ToString() + ".json";
            File.WriteAllText(file, formattedReponse);

            var StartInfo = new ProcessStartInfo()
            {
                Arguments = file,
                FileName = "msedge.exe",
                //FileName = "iexplore.exe",
                UseShellExecute = true
            };

            Process.Start(StartInfo);
        }
    }


}
