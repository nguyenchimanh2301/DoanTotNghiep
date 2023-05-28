using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class HoaDonNhap
{
    public long Id { get; set; }

    public string NhanVienNhap { get; set; } = null!;

    public int? IdnhaCc { get; set; }

    public DateTime NgayNhap { get; set; }

    public byte? DaNhap { get; set; }

    public int? TienThanhToan { get; set; }

    public DateTime NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public virtual ICollection<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; } = new List<ChiTietHoaDonNhap>();

    public virtual NhaCungCap? IdnhaCcNavigation { get; set; }

    public virtual Nhaptb? Nhaptb { get; set; }
}
