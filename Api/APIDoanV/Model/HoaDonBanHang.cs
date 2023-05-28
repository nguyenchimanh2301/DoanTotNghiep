using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class HoaDonBanHang
{
    public long IdhoaDon { get; set; }

    public int? Idphong { get; set; }

    public DateTime? ThoiGianBdau { get; set; }

    public DateTime? ThoiGianKthuc { get; set; }

    public int? DonGiaPhong { get; set; }

    public string? NguoiBan { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? Nguoitao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public virtual ICollection<ChiTietHoaDonBan> ChiTietHoaDonBans { get; } = new List<ChiTietHoaDonBan>();

    public virtual Phong? IdphongNavigation { get; set; }
}
