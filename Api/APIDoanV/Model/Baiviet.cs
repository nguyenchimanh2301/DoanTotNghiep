using System;
using System.Collections.Generic;

namespace APIDoanV.Model;

public partial class Baiviet
{
    public int Idbaiviet { get; set; }

    public int Iduser { get; set; }

    public string? Anh { get; set; }

    public string? Tieude { get; set; }

    public string? Noidung { get; set; }

    public DateTime? Ngaydangbai { get; set; }
}
