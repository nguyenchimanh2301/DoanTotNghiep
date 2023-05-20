using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class BillsNhap
{
    public string Id { get; set; } = null!;

    public string? IdNcc { get; set; }

    public string IdNhanvien { get; set; } = null!;

    public DateTime? DateOrder { get; set; }

    public double? TongTien { get; set; }

    public string? ThanhToan { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillDetailNhap> BillDetailNhaps { get; } = new List<BillDetailNhap>();
}
