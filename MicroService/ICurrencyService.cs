using MicroService.Models;

namespace MicroService
{
    public interface ICurrencyService
    {
        CurrencyRateList GetLatesCurrencyRateList();
    }
}
