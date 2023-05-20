using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class News
{
    public string IdNew { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Image { get; set; } = null!;
}
