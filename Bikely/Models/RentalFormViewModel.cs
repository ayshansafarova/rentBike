using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bikely.Models
{
    public class RentalFormViewModel
    {
        public RentalFormViewModel()
        {
            Id = 0;
        }

        //public IEnumerable<Bikes> Bikes { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [StringLength(255)]
        [Display(Name = "İsmarıc")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [Display(Name = "Velosiped")]
        public int? Bikeİd { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        [Display(Name = "Başlayacağı vaxt")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Qurtaracağı vaxt")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Boş buraxılmamalıdır")]
        public bool isAccepted { get; set; }

        public string User_id { get; set; }
        public virtual ApplicationUser Renter { get; set; }

        public RentalFormViewModel(Rental rental)
        {
            Id = rental.Id;
            Message = rental.Message;
            StartDate = rental.StartDate;
            EndDate = rental.EndDate;
            Bikeİd = rental.BikeId;
            isAccepted = rental.isAccepted;
            User_id = rental.User_id;
        }
    }
}