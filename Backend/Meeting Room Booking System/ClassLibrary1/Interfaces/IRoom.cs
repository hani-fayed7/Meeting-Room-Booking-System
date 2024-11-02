using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Core.Interfaces
{
    public interface IRoom : IRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<Room> GetWithRoomByIdAsync(int id);
    }
}
