using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Meeting_Room_Booking_System.Resources;
using Meeting_Room_Booking_System.Validators;
using Microsoft.AspNetCore.Mvc;
using MRBS.Core.Models;
using MRBS.Services.Interface;

namespace Meeting_Room_Booking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this._mapper = mapper;
            this._roomService = roomService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<RoomResource>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            var roomResources = _mapper.Map<IEnumerable<Room>, IEnumerable<RoomResource>>(rooms);

            return Ok(roomResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomResource>> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomById(id);
            var roomResource = _mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<RoomResource>> CreateRoom([FromBody] SaveRoomResource saveRoomResource)
        {
            var validator = new SaveRoomResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRoomResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var roomToCreate = _mapper.Map<SaveRoomResource, Room>(saveRoomResource);

            var newRoom = await _roomService.CreateRoom(roomToCreate);

            var room = await _roomService.GetRoomById(newRoom.PkRoomId);

            var roomResource = _mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomService.GetRoomById(id);

            await _roomService.DeleteRoom(room);

            return NoContent();
        }
    }
}