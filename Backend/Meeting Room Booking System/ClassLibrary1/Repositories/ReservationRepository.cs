using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Repositories
{
    public class ReservationRepository : Repository<Reservation>, IReservation
    {
        public ReservationRepository(meetingRoomBookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
        {
            return await MyDbContext.Reservations
                .ToListAsync();
        }

        public Task<Reservation> GetWithReservationByIdAsync(int id)
        {
            return MyDbContext.Reservations
                .SingleOrDefaultAsync(a => a.PkReservationId == id);
        }

        private meetingRoomBookingSystemContext MyDbContext
        {
            get { return Context as meetingRoomBookingSystemContext; }
        }
    } 
}
