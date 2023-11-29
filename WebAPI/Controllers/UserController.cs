using Microsoft.AspNetCore.Mvc;
using WebAPI.Dto;
using WebAPI.Interfaces;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGeneric<User> _userRepository;
        public UserController(IGeneric<User> userRepository)
        {
            _userRepository = userRepository;
        }
        //Get:api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>>GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return Ok(users);
        }
        [HttpPost("{id}")]
        public ActionResult<User>GetUserById(int id )
        {
            var user =_userRepository.GetbyId(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] UsersDto userDto)
        {
            try
            {
                var newuser = new User
                {
                    UserName = userDto.UserName,
                    Password = userDto.Password,
                };
                _userRepository.Create(newuser);
                return Ok("User registered successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("authenticate")]
        public ActionResult AuthenticateUser([FromBody] UsersDto usersDto)
        {
            try
            {
                var user = _userRepository.GetAll.SingleOrDefault(u => u.UserName == usersDto.UserName && u.Password == usersDto.Password);
                if(user== null )
                {
                    return Unauthorized("Invalid usernmae or password");
                }
                return Ok(new {Message="Authentication successful",UserId=user.UserId});    


            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
