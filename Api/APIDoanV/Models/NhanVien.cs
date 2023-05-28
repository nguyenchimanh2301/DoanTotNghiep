using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class NhanVien
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? HoVaTen { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? ChucVu { get; set; }

    public virtual ICollection<TinhLuong> TinhLuongs { get; } = new List<TinhLuong>();
}
