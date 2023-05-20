using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class ThietBi
{
    public int Id { get; set; }

    public int? IdloaiTb { get; set; }

    public string? TenThietBi { get; set; }

    public int? DonGia { get; set; }

    public string? Mausac { get; set; }

    public string? Kichthuoc { get; set; }

    public virtual LoaiThietBi? IdloaiTbNavigation { get; set; }

    public virtual ICollection<Lapdat> Lapdats { get; } = new List<Lapdat>();
}
