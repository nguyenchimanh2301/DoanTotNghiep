using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class BillDetailNhap
{
    public string Id { get; set; } = null!;

    public string IdBillNhap { get; set; } = null!;

    public string IdSp { get; set; } = null!;

    public int Sl { get; set; }

    public string DonVi { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual BillsNhap IdBillNhapNavigation { get; set; } = null!;
}
