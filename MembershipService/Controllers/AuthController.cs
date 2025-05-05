using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using AuthLib;
namespace MembershipService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        
        // POST api/<AuthController>
        [HttpPost("Login")]
        public void Login([FromBody] Credentials credentails)
        {

            // Validate the credentials
            if (string.IsNullOrEmpty(credentails.Email) || string.IsNullOrEmpty(credentails.Password))
            {
                // Return a bad request response
                BadRequest("Invalid credentials");
            }
            // Perform login logic here (e.g., check against a database)
            if(credentails.Email== "ravi.tambade@transflower.in" && credentails.Password == "seed")
            {
                // Return a bad request response
                BadRequest("Invalid credentials");
            }
            // If successful, return a success response
            Ok("Login successful");
        }


        // POST api/<AuthController>
        [HttpPost("Register")]
        public void Register([FromBody] string value)
        {


        }



    }
}
