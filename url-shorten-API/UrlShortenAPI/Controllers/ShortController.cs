using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using UrlShortenAPI.Request;
using UrlShortenAPI.Response;
using UrlShortenAPI.Service;

namespace UrlShortenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class ShortController : ControllerBase
    {
        ShortService ShortService { get; set; }
        private readonly ILogger<ShortController> _logger;

        public ShortController(ILogger<ShortController> logger)
        {
            _logger = logger;
            ShortService = new ShortService();
        }

        [HttpPost("/shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortRequest urlRequest)
        {
            ShortResponse response = new ShortResponse();
            response.ShortedUrl = await ShortService.ShortUrl(urlRequest.OriginalUrl);
            return Ok(response);
        }
    }
}
