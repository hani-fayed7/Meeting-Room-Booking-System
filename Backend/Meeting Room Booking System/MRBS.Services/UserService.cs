using MRBS.Core.Interfaces;
using MRBS.Core.Models;
using MRBS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User user)
        {
            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.Users
                .GetAllUsersAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users
                .GetWithUserByIdAsync(id);
        }
    }
}
