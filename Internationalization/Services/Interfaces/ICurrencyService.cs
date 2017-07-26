using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Internationalization.Models;

namespace Internationalization.Services
{
    public interface ICurrencyService
    {
        CultureInfo GetCurrent(CultureInfo currentCulture);
        List<Currency> GetAll();
        string GetSymbol(CultureInfo culture);
    }
}