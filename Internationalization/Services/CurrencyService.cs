using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Internationalization.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;

namespace Internationalization.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IOptions<CurrencySettings> _currencyOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CultureInfo[] _cultures = { new CultureInfo("en-US"), new CultureInfo("zh-CN")};


        private IEnumerable<Currency> Currencies => _cultures
            .Select(c => new Currency { CultureName = c.Name, Symbol = GetSymbol(c) });

        public readonly string DefaultCurrencyCookieName = ".AspNetCore.Currency";

        public CurrencyService(IOptions<CurrencySettings> currencyOptions, IHttpContextAccessor httpContextAccessor)
        {
            _currencyOptions = currencyOptions;
            _httpContextAccessor = httpContextAccessor;
        }

        public Currency GetBySymbol(string symbol)
        {
            return Currencies.FirstOrDefault(c => c.Symbol == symbol);
        }

        public List<Currency> GetAll()
        {
            return Currencies.ToList();
        }

        public CultureInfo GetCurrent()
        {
            // We have a cookie with currency
            var currencyCookie = _httpContextAccessor.HttpContext.Request.Cookies[DefaultCurrencyCookieName];
            if (!string.IsNullOrEmpty(currencyCookie))
            {
                var cultureName = CookieRequestCultureProvider.ParseCookieValue(currencyCookie).Cultures.First();
                return new CultureInfo(cultureName);
            }

            // App settings default is set?
            var appSettingsCurrency = _currencyOptions.Value.DefaultCurrencyCulture;
            if(string.IsNullOrEmpty(appSettingsCurrency))
                return new CultureInfo(appSettingsCurrency);

            // Return current thread culture
            return CultureInfo.CurrentCulture; //server thread
        }

        public string GetSymbol(CultureInfo culture)
        {
            var regionInfo = new RegionInfo(culture.Name);
            return regionInfo.ISOCurrencySymbol;
        }
    }
}
