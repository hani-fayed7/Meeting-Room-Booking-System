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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            this._mapper = mapper;
            this._userService = userService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserResource>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            var userResources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return Ok(userResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<UserResource>> CreateUser([FromBody] SaveUserResource saveUserResource)
        {
            var validator = new SaveUserResourceValidator();
            var validationResult = await validator.ValidateAsync(saveUserResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var userToCreate = _mapper.Map<SaveUserResource, User>(saveUserResource);

            var newUser = await _userService.CreateUser(userToCreate);

            var user = await _userService.GetUserById(newUser.PkUserId);

            var userResource = _mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
                return BadRequest();

            var user = await _userService.GetUserById(id);

            if (user == null)
                return NotFound();
            await _userService.DeleteUser(user);

            return NoContent();
        }
    }
}