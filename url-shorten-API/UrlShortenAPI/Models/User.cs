using System;
using System.Collections.Generic;

namespace UrlShortenAPI.Models;

public partial class User
{
    public string? Initials { get; set; }

    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
