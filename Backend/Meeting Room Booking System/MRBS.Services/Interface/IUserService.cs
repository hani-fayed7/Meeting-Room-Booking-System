using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> CreateUser(User newUser);
        Task DeleteUser(User user);
        Task<User> GetUserById(int id);
    }
}
