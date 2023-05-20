using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class SanPham
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public string? IdLoaiSp { get; set; }

    public string IdNcc { get; set; } = null!;

    public string? MotaSp { get; set; }

    public int? UnitPrice { get; set; }

    public int SoLuong { get; set; }

    public string? Image { get; set; }

    public string? DonViTinh { get; set; }

    public DateTime? NgaySanxuat { get; set; }

    public DateTime? HanSudung { get; set; }

    public DateTime? NgayThem { get; set; }

    public virtual LoaiSp? IdLoaiSpNavigation { get; set; }
}
