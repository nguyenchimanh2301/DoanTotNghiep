using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class DonViTinh
{
    public int Id { get; set; }

    public string? TenDvt { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? NguoiTao { get; set; }

    public DateTime? NgayCapNhat { get; set; }

    public string? NguoiCapNhat { get; set; }

    public virtual ICollection<MatHang> MatHangs { get; } = new List<MatHang>();
}
