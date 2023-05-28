using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class ChiTietHoaDonNhap
{
    public long IdhoaDon { get; set; }

    public int IdmatHang { get; set; }

    public int? SoLuong { get; set; }

    public int? DonGiaNhap { get; set; }

    public virtual HoaDonNhap IdhoaDonNavigation { get; set; } = null!;

    public virtual MatHang IdmatHangNavigation { get; set; } = null!;
}
