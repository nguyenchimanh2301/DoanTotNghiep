using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class LoaiPhong
{
    public int Id { get; set; }

    public string TenLoaiPhong { get; set; } = null!;

    public DateTime? NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public virtual ICollection<Phong> Phongs { get; } = new List<Phong>();
}
