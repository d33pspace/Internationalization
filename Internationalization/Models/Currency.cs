using System.ComponentModel.DataAnnotations;

namespace Internationalization.Models
{
    public class Currency
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Symbol")]
        public string Symbol { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}