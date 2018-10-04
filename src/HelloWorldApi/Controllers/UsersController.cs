using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public string Get([FromQuery] string name)
        {
            return $"Hello {(string.IsNullOrEmpty(name) ? "World" : name)}";
        }
    }
}