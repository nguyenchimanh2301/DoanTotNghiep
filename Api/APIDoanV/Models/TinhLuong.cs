using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class TinhLuong
{
    public int Id { get; set; }

    public string Idusername { get; set; } = null!;

    public DateTime? Ngaybatdau { get; set; }

    public int? LuongCb { get; set; }

    public byte? Dathanhtoan { get; set; }

    public int? Songaynghi { get; set; }

}
