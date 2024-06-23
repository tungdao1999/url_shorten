using Microsoft.EntityFrameworkCore;
using System;
using UrlShortenAPI.Models;

namespace UrlShortenAPI.Service
{
    public interface IShortService
    {
        Task<String> ShortUrl(string originalUrl);
        Task<Url> GetUrlByHash(string hash);
        Url GetExistedHashByOriginal(string originalUrl);

    }
    public class ShortService : IShortService
    {
        public UrlShortenContext _urlShortenContext { get; set; }
        public ShortService(UrlShortenContext urlShortenContext)
        {
            this._urlShortenContext = urlShortenContext;
        }
        public async Task<string> ShortUrl(string OriginalUrl)
        {
            Guid uuid = Guid.NewGuid();
            var hashedUuid = BitConverter.ToString(uuid.ToByteArray()).Replace("-", "").ToLower();

            _urlShortenContext.Urls.Add(new Url
            {
                OriginalUrl = OriginalUrl,
                Hash = hashedUuid,
                Expiration = DateTime.Now.AddDays(7),
                UserId = 1
            });
            _urlShortenContext.SaveChanges();
            return hashedUuid;
        }

        public async Task<Url> GetUrlByHash(string hash)
        {
            var result = await _urlShortenContext.Urls.Where(x => x.Hash == hash).FirstOrDefaultAsync();
            return result;
        }

        public Url GetExistedHashByOriginal(string originalUrl)
        {
            var result = _urlShortenContext.Urls.FirstOrDefault(x => x.OriginalUrl == originalUrl);
            return result;
        }
    }
}
