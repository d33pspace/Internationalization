using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace Internationalization.Services
{
    /// <summary>
    /// This is currently not used. However if you wish to have the localisation data stored in the database, you'd modify this and 
    /// it will become the source of translation strings. You'd simply add a repository on the constructor for the 
    /// data store which will store the data. That way you may have a unified storage location, the only downside is database calls
    /// for all strings. The best would be to use a cache for translation data.
    /// </summary>
    public class MemoryStringLocalizer : IStringLocalizer
    {
        private readonly IList<ResourceString> _resourceStrings;

        public MemoryStringLocalizer(IList<ResourceString> resourceStrings)
        {
            _resourceStrings = resourceStrings;
        }

        public LocalizedString this[string name]
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value ?? name, value == null);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                var format = GetString(name);
                var value = string.Format(format ?? name, arguments);
                return new LocalizedString(name, value, format == null);
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _resourceStrings
                .Where(r => r.Culture == CultureInfo.CurrentCulture.Name)
                .Select(r => new LocalizedString(r.Key, r.Value, true));
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            return new MemoryStringLocalizer(_resourceStrings);
        }

        private string GetString(string name)
        {
            return _resourceStrings
                .Where(r => r.Culture == CultureInfo.CurrentCulture.Name)
                .FirstOrDefault(r => r.Key == name)?.Value;
        }
    }

    public class ResourceString
    {
        public string Culture { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
