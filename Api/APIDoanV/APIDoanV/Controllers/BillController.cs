using Microsoft.AspNetCore.Mvc;
using APIDoanV.Models;
namespace APIDoanV.Controllers
{
    [ApiController]
    public class BillController : Controller
    {
        ApiContext db = new ApiContext();
        [Route("get_all_donhang")]
        [HttpGet]
        public IActionResult Getall()
        {
            var bill = db.Donhangs.Select(x => new
            {
                MaDonHang = x.MaDonHang,
                MaKhachHang = x.MaKhachHang,
                Trangthai = x.Trangthai,
                Ngaydat = x.Ngaydat
            }).ToList();
            return Json(bill);
        }
        [Route("get_all_hoadon")]
        [HttpGet]
        public IActionResult Getall_hd()
        {
          /*  var bill = db.BillsBans.Select(x => new
            {
                Id = x.Id,
                IdKh = x.IdKh,
                TenKh = x.TenKh,
                Trangthai = x.Trangthai,
                Ghichu = x.Ghichu,
                NgayBan = x.NgayBan,
                TongTien = x.TongTien,
            }).ToList();*/
            var result = (from t in db.KhachHangs
                          join n in db.Donhangs on t.Id equals n.MaKhachHang 
                          join s in db.ChiTietDonHangs on n.MaDonHang equals s.MaDonHang
                          where t.Id == n.MaKhachHang && n.MaDonHang==s.MaDonHang
                          select new { t.TenKh, n.MaDonHang,t.DiaChi,n.Ngaydat })
                          .ToList();
            return Json(result);
        }
        [Route("get_chitiet_hoadon")]
        [HttpGet]
        public IActionResult Getall_cthd(int madonhang)
        {
            var result = (from t in db.ChiTietDonHangs
                          join n in db.SanPhams on t.MaSanPham equals n.Id
                          where t.MaSanPham == n.Id
                          select new { t.SoLuong,t.GiaMua,t.MaDonHang,n.Name})
                          .Where(n => n.MaDonHang == madonhang).ToList();
           /* var result = db.ChiTietDonHangs.Select(x => new
            {
                MaChiTietDonHang = x.MaChiTietDonHang,
                MaSanPham = x.MaSanPham,
                GiaMua = x.GiaMua,
                SoLuong = x.SoLuong,
                MaDonHang = x.MaDonHang
            }).Where(x => x.MaDonHang == madonhang).ToList();*/

            return Json(result);
        }

    }
}
