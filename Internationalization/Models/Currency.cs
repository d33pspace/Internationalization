using System.ComponentModel.DataAnnotations;

namespace Internationalization.Models
{
    public class Currency
    {
        public string Symbol { get; set; }
        public string CultureName { get; set; }
    }
}