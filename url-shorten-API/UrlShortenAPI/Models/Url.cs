using System;
using System.Collections.Generic;

namespace UrlShortenAPI.Models;

public partial class Url
{
    public string Hash { get; set; } = null!;

    public int? UserId { get; set; }

    public string? OriginalUrl { get; set; }

    public DateTime? Expiration { get; set; }
}
