using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Capital
    {
        public string figure { get; set; }
        public string currency { get; set; }
        public string date { get; set; }
    }

    public class DescriptionValues
    {
        public string change_date { get; set; }
        public string officer_name { get; set; }
        public string termination_date { get; set; }
        public List<Capital> capital { get; set; }
        public string date { get; set; }
        public string made_up_date { get; set; }
        public string description { get; set; }
        public string appointment_date { get; set; }
    }

    public class FilingHistoryLinks
    {
        public string self { get; set; }
        public string document_metadata { get; set; }
    }

    public class Resolution
    {
        public string category { get; set; }
        public string description { get; set; }
        public string subcategory { get; set; }
        public string type { get; set; }
        public DescriptionValues description_values { get; set; }
    }

    public class Annotation
    {
        public string annotation { get; set; }
        public string category { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public DescriptionValues description_values { get; set; }
        public string type { get; set; }
    }

    public class FilingHistoryItem
    {
        public string action_date { get; set; }
        public string category { get; set; }
        public string date { get; set; }
        public string description { get; set; }
        public DescriptionValues description_values { get; set; }
        public FilingHistoryLinks links { get; set; }
        public string subcategory { get; set; }
        public string type { get; set; }
        public int pages { get; set; }
        public string barcode { get; set; }
        public string transaction_id { get; set; }
        public bool? paper_filed { get; set; }
        public List<Resolution> resolutions { get; set; }
        public List<Annotation> annotations { get; set; }
    }

    public class FilingHistoryResponse
    {
        public List<FilingHistoryItem> items { get; set; }
        public string filing_history_status { get; set; }
        public int total_count { get; set; }
        public int start_index { get; set; }
        public int items_per_page { get; set; }
    }


}
