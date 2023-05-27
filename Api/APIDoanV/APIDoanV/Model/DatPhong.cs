using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class DatPhong
{
    public int Id { get; set; }

    public int Idkh { get; set; }

    public string? Tenkh { get; set; }

    public DateTime? Ngaydat { get; set; }

    public DateTime? Ngaytra { get; set; }

    public string? Thanhtien { get; set; }

    public bool? Thanhtoan { get; set; }

    public virtual KhachHang IdkhNavigation { get; set; } = null!;
}
