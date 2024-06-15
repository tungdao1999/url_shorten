using Microsoft.EntityFrameworkCore;
using System;
using UrlShortenAPI.Models;

namespace UrlShortenAPI.Service
{
    public class ShortService
    {
        public UrlShortenContext UrlShortenContext { get; set; }
        public ShortService()
        {
            this.UrlShortenContext = new UrlShortenContext();
        }
        public async Task<string> ShortUrl(string OriginalUrl)
        {
            Guid uuid = Guid.NewGuid();
            var hashedUuid = BitConverter.ToString(uuid.ToByteArray()).Replace("-", "").ToLower();

            UrlShortenContext.Urls.Add(new Url
            {
                OriginalUrl = OriginalUrl,
                Hash = hashedUuid,
                Expiration = DateTime.Now.AddDays(7),
                UserId = 1
            });
            UrlShortenContext.SaveChanges();
            return hashedUuid;
        }

        public async Task<Url> GetUrlByHash(string hash)
        {
            var result = await UrlShortenContext.Urls.Where(x => x.Hash == hash).FirstOrDefaultAsync();
            return result;
        }
    }
}
