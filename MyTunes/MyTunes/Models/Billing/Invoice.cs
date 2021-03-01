using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models
{
   public  class Invoice
    {
        public int InvoiceId { get; set; } //pk
        public int CustomerId { get; set; } //fk
        public DateTime InvoiceDate { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingPostalCode { get; set; }
        public int Total { get; set; }

    }
}

