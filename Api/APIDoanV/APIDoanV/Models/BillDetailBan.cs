using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class BillDetailBan
{
    public int Id { get; set; }

    public int IdBillBan { get; set; }

    public string? Masp { get; set; }

    public int? Giaban { get; set; }

    public short? Soluong { get; set; }

    public double? Chietkhau { get; set; }

    public short? Tralai { get; set; }
}
