using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace Task1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if(_context.Users.Any(u=>u.Email ==u.Email))
            {
                return BadRequest("User already Exist");
            }
            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                CreatedAt = DateTime.Now,
                status=true

                
            };
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User successfully created");
            
        }
        
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Email == request.Email);
            if (user == null)
            {
                return BadRequest("User not found ");
            }
            if(user.status == false)
            {
                return BadRequest("Not Verified");
            }
            if(user.Password!= request.Password)
            {
                return BadRequest("Incorrect password");
            }
            return Ok(user);

            
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> GetUser(int Id)
        {   var data = await _context.Users.FindAsync(Id);

            // var data = await _context.Users.FindAsync(Id);
            return data;


        }
        
    }
}
