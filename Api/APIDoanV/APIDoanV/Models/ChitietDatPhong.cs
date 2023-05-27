using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class ChitietDatPhong
{
    public int Id { get; set; }

    public int Iddondat { get; set; }

    public double? Tongthoigiandat { get; set; }

    public int? Dongia { get; set; }

    public double? Thanhtien { get; set; }

    public virtual DatPhong IddondatNavigation { get; set; } = null!;
}
