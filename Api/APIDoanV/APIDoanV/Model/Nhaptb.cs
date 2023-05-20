using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class Nhaptb
{
    public long Idhd { get; set; }

    public string? Idthietbi { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGiaNhap { get; set; }

    public virtual HoaDonNhap IdhdNavigation { get; set; } = null!;
}
