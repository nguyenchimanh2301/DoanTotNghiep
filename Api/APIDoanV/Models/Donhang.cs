using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class Donhang
{
    public int MaDonHang { get; set; }

    public string MaKhachHang { get; set; } = null!;

    public DateTime Ngaydat { get; set; }

    public string? Trangthai { get; set; }
}
