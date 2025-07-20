using System;
using System.Collections.Generic;

namespace SharingPicture.Models;

public partial class Album
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Picture> Pictures { get; set; } = new List<Picture>();
}
