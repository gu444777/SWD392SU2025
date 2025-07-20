using System;
using System.Collections.Generic;

namespace SharingPicture.Models;

public partial class PictureLike
{
    public int UserId { get; set; }

    public int PictureId { get; set; }

    public DateTime LikedAt { get; set; }

    public virtual Picture Picture { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
