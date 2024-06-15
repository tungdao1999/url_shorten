namespace UrlShortenAPI.Response
{
    public class RedirectResponse
    {
        public string RedirectUrl { get; set; } = null!;

        public RedirectResponse(string redirectUrl) 
        {  
            RedirectUrl = redirectUrl; 
        }
    }
}
