using System;
using System.Collections.Generic;
using System.Text;

namespace MyTunes.Models.Billing
{
    public class InvoiceLine
    {
        public int InvoiceLineId { get; set; } //pk
        public int InvoiceId { get; set; } //fk
        public int TrackId { get; set; } //fk

        public int UnitPrice { get; set; }

        public int Quantity { get; set; }

    }
}
