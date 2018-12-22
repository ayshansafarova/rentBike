using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bikely.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual ApplicationUser Renter { get; set; }

        public int BikeId { get; set; }
        [ForeignKey("BikeId")]
        public Bike Bike { get; set; }

        [Display(Name = "İsmarıc")]
        [StringLength(255)]
        public string Message { get; set; }

        [Display(Name = "Başlayacağı vaxt")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Qurtaracağı vaxt")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Qəbul olunub?")]
        public bool isAccepted { get; set; }
    }
}