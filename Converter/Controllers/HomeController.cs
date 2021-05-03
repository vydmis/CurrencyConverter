using Converter.Models;
using MicroService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;

namespace Converter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public HomeController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            var currencyRatesData = _currencyService.GetLatesCurrencyRateList();
            CurrencyRateListViewModel model = new CurrencyRateListViewModel()
            {
                Time = currencyRatesData.Time,
                ListCurrencyRate = currencyRatesData.ListCurrencyRate.Select(x => new CurrencyRateViewModel
                {
                    Currency = x.Currency,
                    Rate = x.Rate
                }).ToList(),
                ConvertedCurrency = new ConvertedCurrencyViewModel()
                {
                    FirstCurrency = "",
                    SecondCurrency = "",
                    Amount = 0,
                    CalculatedValue = 0
                }
        };
            
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CalculateCurrencyRate(string firstCurrency, string secondCurrency, decimal amount, DateTime date) 
        {
            var currencyRatesData = _currencyService.GetLatesCurrencyRateList();
            var firstRate = currencyRatesData.ListCurrencyRate.Where(x => x.Currency == firstCurrency).Select(x => x.Rate).SingleOrDefault();
            var amountInEuro = amount / firstRate;
            var secondRate = currencyRatesData.ListCurrencyRate.Where(x => x.Currency == secondCurrency).Select(x => x.Rate).SingleOrDefault();

            var model = new ConvertedCurrencyViewModel() {
                FirstCurrency = firstCurrency,
                SecondCurrency = secondCurrency,
                Amount = amount,
                CalculatedValue = Math.Round(amountInEuro * secondRate, 2)
            };
            return PartialView("Result", model);
        }
    }
}
