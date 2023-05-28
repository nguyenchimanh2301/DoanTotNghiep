using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class ChitietDatPhong
{
    public int Idp { get; set; }

    public int Iddondat { get; set; }

    public double? Tongthoigiandat { get; set; }

    public int? Dongia { get; set; }

    public double? Thanhtien { get; set; }

    public virtual Phong IdpNavigation { get; set; } = null!;
}
