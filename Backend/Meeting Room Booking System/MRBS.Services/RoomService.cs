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
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Room> CreateRoom(Room newRoom)
        {
            await _unitOfWork.Rooms.AddAsync(newRoom);
            await _unitOfWork.CommitAsync();
            return newRoom;
        }

        public async Task DeleteRoom(Room room)
        {
            _unitOfWork.Rooms.Remove(room);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _unitOfWork.Rooms
                .GetAllRoomsAsync();
        }
        public async Task<Room> GetRoomById(int id)
        {
            return await _unitOfWork.Rooms
                .GetWithRoomByIdAsync(id);
        }
    }
}
