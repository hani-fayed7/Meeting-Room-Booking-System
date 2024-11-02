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
    public class UserRepository : Repository<User>, IUser
    {
        public UserRepository(meetingRoomBookingSystemContext context)
            : base(context)
        { }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await MyDbContext.Users
                .ToListAsync();
        }

        public Task<User> GetWithUserByIdAsync(int id)
        {
            return MyDbContext.Users
                .SingleOrDefaultAsync(a => a.PkUserId == id);
        }

        private meetingRoomBookingSystemContext MyDbContext
        {
            get { return Context as meetingRoomBookingSystemContext; }
        }
    }
}
