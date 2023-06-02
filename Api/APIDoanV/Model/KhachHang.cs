using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class KhachHang
{
    public int Id { get; set; }

    public string TenKh { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Note { get; set; }

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();

    public virtual ICollection<DatPhong> DatPhongs { get; } = new List<DatPhong>();
}
