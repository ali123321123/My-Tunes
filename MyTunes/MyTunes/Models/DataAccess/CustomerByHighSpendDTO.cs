using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTunes.Models.DataAccess
{
    public class CustomerByHighSpendDTO
    {
        public int CustomerId { get; set; }
        public decimal SumOFTotal { get; set; }
    }
}
