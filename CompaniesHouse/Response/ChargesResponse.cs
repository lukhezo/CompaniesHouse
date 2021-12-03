using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesHouse.Response
{
    public class PersonsEntitled
    {
        public string name { get; set; }
    }

    public class Classification
    {
        public string description { get; set; }
        public string type { get; set; }
    }

    public class ChargeLinks
    {
        public string self { get; set; }
        public string filing { get; set; }
    }

    public class Transaction
    {
        public string filing_type { get; set; }
        public string delivered_on { get; set; }
        public Links links { get; set; }
    }

    public class Particulars
    {
        public bool floating_charge_covers_all { get; set; }
        public bool contains_floating_charge { get; set; }
        public bool contains_negative_pledge { get; set; }
        public bool contains_fixed_charge { get; set; }
        public string type { get; set; }
        public string description { get; set; }
    }

    public class SecuredDetails
    {
        public string description { get; set; }
        public string type { get; set; }
    }

    public class ChargeItem
    {
        public string delivered_on { get; set; }
        public string status { get; set; }
        public int charge_number { get; set; }
        public List<PersonsEntitled> persons_entitled { get; set; }
        public Classification classification { get; set; }
        public string etag { get; set; }
        public string created_on { get; set; }
        public string charge_code { get; set; }
        public ChargeLinks links { get; set; }
        public List<Transaction> transactions { get; set; }
        public Particulars particulars { get; set; }
        public SecuredDetails secured_details { get; set; }
        public string satisfied_on { get; set; }
    }

    public class ChargesResponse
    {
        public int total_count { get; set; }
        public int part_satisfied_count { get; set; }
        public List<ChargeItem> items { get; set; }
        public int unfiltered_count { get; set; }
        public int satisfied_count { get; set; }
    }


}
