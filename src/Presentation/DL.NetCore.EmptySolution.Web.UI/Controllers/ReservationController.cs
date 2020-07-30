using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DL.NetCore.EmptySolution.Web.UI.Models.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace DL.NetCore.EmptySolution.Web.UI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index(string c, string t)
        {
            var vm = new ReservationListViewModel
            {
                Filters = new ReservationFiltersViewModel
                {
                    ClientNameSearchQuery = c,
                    ReservationTypeSearchQuery = t,
                    // You would normally get the list from your database
                    AvailableReservationTypes = GetFakeReservationStatusesFromDb()
                        .ToDictionary(x => x.StatusId, x => x.Status)
                },
                Reservations = Enumerable.Empty<ReservationViewModel>()
            };

            // You would normally get the list of reservations from your database
            var reservationsFromDb = GetFakeReservationsFromDb();

            // Filters
            if (!String.IsNullOrWhiteSpace(c))
            {
                reservationsFromDb = reservationsFromDb
                    .Where(x => x.ClientName.Contains(c, StringComparison.InvariantCultureIgnoreCase));
            }
            if (!String.IsNullOrWhiteSpace(t))
            {
                reservationsFromDb = reservationsFromDb
                     .Where(x => x.ReservationStatus.StatusId.Contains(t, StringComparison.InvariantCultureIgnoreCase));
            }

            vm.Reservations = reservationsFromDb
                .Select(x => new ReservationViewModel
                {
                    ReservationId = x.ReservationId,
                    ClientName = x.ClientName,
                    ReservationType = x.ReservationStatus.Status,
                    StartTime = x.StartTimeUtc.ToLocalTime()
                });

            return View(vm);
        }

        [HttpPost]
        public IActionResult Search(ReservationFiltersViewModel filters)
        {
            return RedirectToAction(nameof(Index), 
                new { c = filters.ClientNameSearchQuery, t = filters.ReservationTypeSearchQuery });
        }

        private IEnumerable<FakeReservationStatusEntity> GetFakeReservationStatusesFromDb()
        {
            return new List<FakeReservationStatusEntity>
            {
                new FakeReservationStatusEntity { StatusId = "Success", Status = "Inactive Reservation" },
                new FakeReservationStatusEntity { StatusId = "Approved", Status = "Active Reservation" },
                new FakeReservationStatusEntity { StatusId = "Pending", Status = "Pending Reservation" }
            };
        }

        private IEnumerable<FakeReservationEntity> GetFakeReservationsFromDb()
        {
            var statuses = GetFakeReservationStatusesFromDb()
                .ToArray();
            
            // Randomly assign the status to reservations, just for fun
            Random rnd = new Random();

            return new List<FakeReservationEntity>
            {
                new FakeReservationEntity
                {
                    ReservationId = 1,
                    ClientId = 1,
                    ClientName = "Allen Tim",
                    StartTimeUtc = new DateTime(2020, 7, 29),
                    CreatedByUserId = 1,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                },
                new FakeReservationEntity
                {
                    ReservationId = 2,
                    ClientId = 1,
                    ClientName = "Allen Tim",
                    StartTimeUtc = new DateTime(2019, 6, 24),
                    CreatedByUserId = 2,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                },
                new FakeReservationEntity
                {
                    ReservationId = 3,
                    ClientId = 2,
                    ClientName = "Crystal / Bill",
                    StartTimeUtc = new DateTime(2018, 5, 21),
                    CreatedByUserId = 1,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                },
                new FakeReservationEntity
                {
                    ReservationId = 4,
                    ClientId = 3,
                    ClientName = "Repaint Service",
                    StartTimeUtc = new DateTime(2017, 4, 23),
                    CreatedByUserId = 1,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                },
                new FakeReservationEntity
                {
                    ReservationId = 5,
                    ClientId = 4,
                    ClientName = "Sales Monica Owens",
                    StartTimeUtc = new DateTime(2016, 4, 11),
                    CreatedByUserId = 1,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                },
                new FakeReservationEntity
                {
                    ReservationId = 6,
                    ClientId = 5,
                    ClientName = "BLues Ehwood Company",
                    StartTimeUtc = new DateTime(2015, 3, 8),
                    CreatedByUserId = 1,
                    ReservationStatus = statuses[rnd.Next(0, statuses.Length)]
                }
            };
        }
    }
}
