using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Internationalization.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Symbol")]
        public string Name { get; set; }

        public double Amount { get; set; }

        public int? CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
