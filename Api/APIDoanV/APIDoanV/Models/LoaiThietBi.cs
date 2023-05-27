using System;
using System.Collections.Generic;

namespace APIDoanV.Models;

public partial class LoaiThietBi
{
    public int Id { get; set; }

    public string? TenLoaiTb { get; set; }

    public string? Mota { get; set; }

    public virtual ICollection<ThietBi> ThietBis { get; } = new List<ThietBi>();
}
