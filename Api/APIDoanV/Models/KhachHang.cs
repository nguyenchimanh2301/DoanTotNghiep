using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class KhachHang
{
    public string Id { get; set; } = null!;

    public string TenKh { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Note { get; set; }
}
