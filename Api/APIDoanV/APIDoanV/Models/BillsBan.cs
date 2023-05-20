using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class BillsBan
{
    public int IdBillBan { get; set; }

    public string? IdKh { get; set; }

    public DateTime? NgayBan { get; set; }

    public string? SoHoadon { get; set; }

    public string? Manguoidung { get; set; }
}
