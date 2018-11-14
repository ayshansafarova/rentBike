using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bikely.Models
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public Category Category { get; set; }

        [Required]
        public byte CategoryId { get; set; }

        [Required]
        public int priceDaily { get; set; }

        public int? priceWeekly { get; set; }
        public int? priceMonthly { get; set; }

        public virtual ApplicationUser User { get; set; }






    }
}