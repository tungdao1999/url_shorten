using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenAPI.Controllers
{
    [ApiController]
    [Route("/users")]
    [EnableCors("AllowOrigin")]
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult MyUser()
        {
            return View();
        }
    }
}
