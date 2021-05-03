using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class ConvertedCurrencyViewModel
    {
        public string FirstCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal CalculatedValue { get; set; }
    }
}
