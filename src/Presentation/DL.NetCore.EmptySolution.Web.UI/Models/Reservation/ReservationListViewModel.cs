using System.Collections.Generic;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Reservation
{
    public class ReservationListViewModel
    {
        public ReservationFiltersViewModel Filters { get; set; }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}
