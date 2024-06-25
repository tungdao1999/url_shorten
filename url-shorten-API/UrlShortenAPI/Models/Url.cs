using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrlShortenAPI.Models;

public partial class Url
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Hash { get; set; } = null!;

    public int? UserId { get; set; }

    public string? OriginalUrl { get; set; }

    public DateTime? Expiration { get; set; }
}
