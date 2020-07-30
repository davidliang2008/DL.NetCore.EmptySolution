using System;

namespace DL.NetCore.EmptySolution.Web.UI.Models.Reservation
{
    public class FakeReservationEntity
    {
        public int ReservationId { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public DateTime StartTimeUtc { get; set; }
        public FakeReservationStatusEntity ReservationStatus { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
