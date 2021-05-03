using MicroService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MicroService
{
    public class CurrencyServise : ICurrencyService
    {
        private const string Uri = "../RelatedItems/eurofxref-hist.csv";

        public CurrencyRateList GetLatesCurrencyRateList() 
        {
            string header = File.ReadAllLines(Uri)[0].ToString();
            string line = File.ReadAllLines(Uri).Skip(1).FirstOrDefault();

            var currencyRateList = FromCsv(header, line);

            return currencyRateList;
        }

        public List<CurrencyRateList> GetAllCurrencyRateList()
        {
            string header = File.ReadAllLines(Uri)[0].ToString();
            List<string> linesList = File.ReadAllLines(Uri).Skip(1).ToList();
            var allCurrencyRateList = new List<CurrencyRateList>();

            foreach (var item in linesList) 
            {
                var currencyRateList = FromCsv(header, item);
                allCurrencyRateList.Add(currencyRateList);
            }
            
            return allCurrencyRateList;
        }

        private CurrencyRateList FromCsv(string header, string csvLine)
        {
            string[] headerValues = header.Split(',');
            string[] values = csvLine.Split(',');
            CurrencyRateList dailyValues = new CurrencyRateList();
            
            dailyValues.Time = Convert.ToDateTime(values[0]);
            dailyValues.ListCurrencyRate = new List<CurrencyRate>();

            for (int i = 1; i < headerValues.Count() - 1; i++) 
            {
                var currencyRate = new CurrencyRate
                {
                    Currency = headerValues[i]
                };

                if (values[i] != "N/A")
                {
                    var value = values[i].Replace('.', ',');
                    currencyRate.Rate = Convert.ToDecimal(value);
                }
                else 
                {
                    currencyRate.Rate = 0;
                }
                
                dailyValues.ListCurrencyRate.Add(currencyRate);
            }
            return dailyValues;
        }
    }
}
