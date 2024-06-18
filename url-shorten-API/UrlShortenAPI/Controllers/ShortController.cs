using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using UrlShortenAPI.Request;
using UrlShortenAPI.Response;
using UrlShortenAPI.Service;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace UrlShortenAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("AllowOrigin")]
    public class ShortController : ControllerBase
    {
        private readonly IShortService _shortService;
        private readonly ILogger<ShortController> _logger;

        public ShortController(IShortService shortService, ILogger<ShortController> logger)
        {
            _shortService = shortService;
            _logger = logger;
        }

        [HttpPost("/shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortRequest urlRequest)
        {
            ShortResponse response = new ShortResponse();
            if (String.IsNullOrEmpty(urlRequest.OriginalUrl))
            {
                return BadRequest();
            }
            var exsitedUrl = _shortService.GetExistedHashByOriginal(urlRequest.OriginalUrl);
            // Check if the original url existed before
            if (exsitedUrl != null)
            {
                // return exsited hash from database
                response.ShortedUrl = exsitedUrl.Hash ?? String.Empty;
            }
            response.ShortedUrl = await _shortService.ShortUrl(urlRequest.OriginalUrl) ?? String.Empty;
            return Ok(response);
        }
    }
}
