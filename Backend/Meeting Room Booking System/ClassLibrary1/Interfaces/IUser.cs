using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Interfaces
{
    public interface IUser : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetWithUserByIdAsync(int id);
    }
}
