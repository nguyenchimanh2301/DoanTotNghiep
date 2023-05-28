using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class ChiTietDonHang
{
    public int MaChiTietDonHang { get; set; }

    public int MaDonHang { get; set; }

    public string MaSanPham { get; set; } = null!;

    public int SoLuong { get; set; }

    public int GiaMua { get; set; }
}
