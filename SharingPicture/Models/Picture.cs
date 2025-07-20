using System;
using System.Collections.Generic;

namespace SharingPicture.Models;

public partial class Picture
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime UploadedAt { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PictureLike> PictureLikes { get; set; } = new List<PictureLike>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
