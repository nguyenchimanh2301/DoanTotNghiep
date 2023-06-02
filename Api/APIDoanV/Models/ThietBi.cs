using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class ThietBi
{
    public int Id { get; set; }

    public int? IdloaiTb { get; set; }

    public string? TenThietBi { get; set; }

    public int? DonGia { get; set; }

    public string? Mausac { get; set; }

    public string? Kichthuoc { get; set; }


}
