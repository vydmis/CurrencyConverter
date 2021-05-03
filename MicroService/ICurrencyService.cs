using MicroService.Models;
using System.Collections.Generic;

namespace MicroService
{
    public interface ICurrencyService
    {
        CurrencyRateList GetLatesCurrencyRateList();
        List<CurrencyRateList> GetAllCurrencyRateList();
    }
}
