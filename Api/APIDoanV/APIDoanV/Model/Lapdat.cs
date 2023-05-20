using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class Lapdat
{
    public int Id { get; set; }

    public int? Idphong { get; set; }

    public int? IdthietBi { get; set; }

    public int? Sllapdat { get; set; }

    public DateTime? NgayLapdat { get; set; }

    public bool? TinhTrang { get; set; }

    public virtual Phong? IdphongNavigation { get; set; }

    public virtual ThietBi? IdthietBiNavigation { get; set; }
}
