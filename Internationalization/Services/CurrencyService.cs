using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Internationalization.Data;
using Internationalization.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Internationalization.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IOptions<CurrencySettings> _currencyOptions;

        private readonly List<Currency> _currencies = new List<Currency>
        {
            new Currency { Symbol = "USD", CultureName = "en-US"},
            new Currency { Symbol = "Yuan", CultureName = "zh-CH"},
        };

        public CurrencyService(IOptions<CurrencySettings> currencyOptions)
        {
            _currencyOptions = currencyOptions;
        }

        public Currency GetBySymbol(string symbol)
        {
            return _currencies.FirstOrDefault(c => c.Symbol == symbol);
        }

        public List<Currency> GetAll()
        {
            return _currencies;
        }

        public CultureInfo GetCurrent(CultureInfo currentCulture)
        {
            if (currentCulture.Name == "CN")
                return currentCulture;
            return new CultureInfo(_currencyOptions.Value.DefaultCurrencyCulture);
        }

        public string GetSymbol(CultureInfo culture)
        {
            var regionInfo = new RegionInfo(culture.Name);
            return regionInfo.ISOCurrencySymbol;
        }
    }
}
