using APIDoanV.Models;
using System.Collections.Generic;
namespace APIDoanV.Entities
{
    public class Hoadonbancs
    {
        public KhachHang khach { get; set; } 
        public List<BillDetailBan> chitiethoadonban { get; set; }

    }
}
