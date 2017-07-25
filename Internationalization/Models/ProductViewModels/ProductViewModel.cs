using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Internationalization.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CurrencyId { get; set; }

        public double Amount { get; set; }

        public List<SelectListItem> CurrencyList { get; set; }

    }
}
