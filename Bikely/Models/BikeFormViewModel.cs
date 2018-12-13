using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bikely.Models;

namespace Bikely.Models
{
    public class BikeFormViewModel
    {
        public BikeFormViewModel()
        {
            Id = 0;
        }

        public IEnumerable<Category> Categories { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [Display(Name = "Kateqoriya")]
        public byte? CategoryId { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [Display(Name = "Günlük qiymət")]
        public int priceDaily { get; set; }

        [Display(Name = "Həftəlik qiymət")]
        public int? priceWeekly { get; set; }

        [Display(Name = "Aylıq qiymət")]
        public int? priceMonthly { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Bike" : "New Bike";
            }
        }

        public BikeFormViewModel(Bike bike)
        {
            Id = bike.Id;
            Description = bike.Description;
            priceDaily = bike.priceDaily;
            priceMonthly = bike.priceMonthly;
            priceWeekly = bike.priceWeekly;
            CategoryId = bike.CategoryId;
        }
        

    }
}