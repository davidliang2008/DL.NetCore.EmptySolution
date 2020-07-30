using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Reservation
{
    public class ReservationViewModel
    {
        public int ReservationId { get; set; }
        public string ReservationType { get; set; }
        public string ClientName { get; set; }
        public DateTime StartTime { get; set; }
    }
}
