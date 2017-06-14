using System;

namespace Internationalization.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public DateTime DonationDate { get; set; }

        public double Amount { get; set; }
    }
}