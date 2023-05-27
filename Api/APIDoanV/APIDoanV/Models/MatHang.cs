using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class MatHang
{
    public int Id { get; set; }

    public string TenMatHang { get; set; } = null!;

    public int? Dvt { get; set; }

    public int DonGiaBan { get; set; }

    public int? Tile { get; set; }

    public int? IdCha { get; set; }

    public string? Nguoitao { get; set; }

    public DateTime? Ngaytao { get; set; }

    public string? NguoiCapNhat { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; } = new List<ChiTietHoaDonBan>();

    public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; } = new List<ChiTietHoaDonNhap>();

    public virtual DonViTinh? DvtNavigation { get; set; }
}
