using MRBS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRBS.Services.Interface
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room> CreateRoom(Room newRoom);
        Task DeleteRoom(Room room);
        Task<Room> GetRoomById(int id);
    }
}
