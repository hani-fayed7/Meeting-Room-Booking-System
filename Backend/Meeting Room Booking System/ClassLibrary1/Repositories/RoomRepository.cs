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
    public class RoomRepository : Repository<Room>, IRoom
    {
        public RoomRepository(meetingRoomBookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await MyDbContext.Rooms
                .ToListAsync();
        }

        public Task<Room> GetWithRoomByIdAsync(int id)
        {
            return MyDbContext.Rooms
                .SingleOrDefaultAsync(a => a.PkRoomId == id);
        }

        private meetingRoomBookingSystemContext MyDbContext
        {
            get { return Context as meetingRoomBookingSystemContext; }
        }
    }
}
