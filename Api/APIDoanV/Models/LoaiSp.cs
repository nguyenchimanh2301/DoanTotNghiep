using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class LoaiSp
{
    public string Id { get; set; } = null!;

    public string? Tenloai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
