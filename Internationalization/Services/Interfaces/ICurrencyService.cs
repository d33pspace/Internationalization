using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Internationalization.Models;

namespace Internationalization.Services
{
    public interface ICurrencyService
    {
        CultureInfo GetCurrent();
        List<Currency> GetAll();
        string GetSymbol(CultureInfo culture);
    }
}