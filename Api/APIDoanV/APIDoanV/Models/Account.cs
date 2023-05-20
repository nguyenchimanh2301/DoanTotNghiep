using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class Account
{
    public int MaTaiKhoan { get; set; }

    public string? MaNguoiDung { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public DateTime? NgayBatDau { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public bool? TrangThai { get; set; }

    public string? LoaiQuyen { get; set; }

    public virtual User? MaNguoiDungNavigation { get; set; }
}
