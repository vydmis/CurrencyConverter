using MicroService;
using System;
using System.Collections.Generic;

namespace MicroService.Models
{
    public class CurrencyRateList
    {
        public DateTime Time { get; set; }
        public IList<CurrencyRate> ListCurrencyRate { get; set; }
    }
}
