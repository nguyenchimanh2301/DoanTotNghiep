using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class ChiTietHoaDonBan
{
    public long IdhoaDon { get; set; }

    public int IdmatHang { get; set; }

    public int? Sl { get; set; }

    public int? DonGiaBan { get; set; }

    public virtual HoaDonBanHang IdhoaDonNavigation { get; set; } = null!;

    public virtual MatHang IdmatHangNavigation { get; set; } = null!;
}
