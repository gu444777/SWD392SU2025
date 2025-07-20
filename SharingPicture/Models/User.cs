using System;
using System.Collections.Generic;

namespace SharingPicture.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? AvatarPath { get; set; }

    public string? Bio { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PictureLike> PictureLikes { get; set; } = new List<PictureLike>();

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}
