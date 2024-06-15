using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortenAPI.Response;
using UrlShortenAPI.Service;

namespace UrlShortenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class RedirectController : ControllerBase
    {
        ShortService ShortService { get; set; }
        private readonly ILogger<ShortController> _logger;

        public RedirectController(ILogger<ShortController> logger) {
            _logger = logger;
            ShortService = new ShortService();
        }
        [HttpGet]
        [Route("{id?}")]
        public IActionResult Index(string id)
        {
            var url = ShortService.GetUrlByHash(id);
            if (url?.Result?.OriginalUrl == null)
            {
                return NotFound();
            }
            RedirectResponse response = new RedirectResponse(url.Result.OriginalUrl);

            return Ok(response);
        }
    }
}
