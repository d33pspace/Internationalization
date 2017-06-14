using System.ComponentModel.DataAnnotations;

namespace Internationalization.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Display(Name = "Symbol")]
        public string Symbol { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}