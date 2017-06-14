using System;
using System.ComponentModel.DataAnnotations;

namespace Internationalization.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Donation date field is required.")]
        [Display(Name = "Date")]
        public DateTime DonationDate { get; set; }

        [Required(ErrorMessage = "The Donation date field is required.")]
        [Display(Name = "Donation Amount")]
        public double Amount { get; set; }
    }
}