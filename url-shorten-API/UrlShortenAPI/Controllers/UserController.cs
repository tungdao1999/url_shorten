using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace UrlShortenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
