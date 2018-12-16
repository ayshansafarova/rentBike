using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bikely.Models
{
    public class Bike
    {
        public int Id { get; set; }
        
        [StringLength(255)]
        [Display(Name = "Qısa məlumat")]
        public string Description { get; set; }

        public byte CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Display(Name = "Günlük qiymət")]
        public int priceDaily { get; set; }
        [Display(Name = "Həftəlik qiymət")]
        public int? priceWeekly { get; set; }
        [Display(Name = "Aylıq qiymət")]
        public int? priceMonthly { get; set; }

        [Display(Name = "Aktivlik")]
        public bool isActive { get; set; }
        [Display(Name = "Foto")]
        public byte[] Image { get; set; }

        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual ApplicationUser User { get; set; }
    }
}