using MicroService.Models;
using System;
using System.Collections.Generic;

namespace Converter.Models
{
    public class CurrencyRateListViewModel
    {
        public DateTime Time { get; set; }
        public IList<CurrencyRateViewModel> ListCurrencyRate { get; set; }
        public ConvertedCurrencyViewModel ConvertedCurrency { get; set; }
    }
}
