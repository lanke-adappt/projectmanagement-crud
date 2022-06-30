using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Shared.Models;

namespace Task1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetails _IUserDetails;
        public UserDetailsController(IUserDetails iUserDetails)
        {
            _IUserDetails = iUserDetails;
        }
        [HttpGet]
        public async Task<List<UserDetails>> Get()
        {
            return await Task.FromResult(_IUserDetails.GetUserDetails());

        }
        [HttpGet("{Id}")]
        public IActionResult Get(int Id )
        {
            UserDetails userDetail = _IUserDetails.GetUserData(Id);
            if(userDetail != null)
            {
                return Ok(userDetail);
            }
            return NotFound();
        }
        [HttpPost]
        public void Post(UserDetails userDetail)
        {
            _IUserDetails.AddUserDetails(userDetail);
        
        }
        [HttpPut]
        public void Put(UserDetails userDetail)
        {
            _IUserDetails.UpdateUserDetails(userDetail);
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            _IUserDetails.DeleteUserDetails(id);
            return Ok();
        }
    }
}
