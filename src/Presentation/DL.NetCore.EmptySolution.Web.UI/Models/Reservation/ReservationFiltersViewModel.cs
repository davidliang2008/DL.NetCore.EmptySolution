using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Reservation
{
    public class ReservationFiltersViewModel
    {
        [Display(Name = "Client name")]
        public string ClientNameSearchQuery { get; set; }

        [Display(Name = "Reservation type")]
        public string ReservationTypeSearchQuery { get; set; }

        public IDictionary<string, string> AvailableReservationTypes { get; set; }
    }
}
