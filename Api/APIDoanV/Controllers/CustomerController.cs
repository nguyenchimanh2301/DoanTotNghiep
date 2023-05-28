using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using APIDoanV.Model;


namespace APIDoanV.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {
        QuanlyhomestayContext dbc = new QuanlyhomestayContext();
        [Route("getacc")]
        [HttpGet]
        public IActionResult Getuser()
        {
            var result = dbc.Accounts.Select(x => new
            {
                TaiKhoan = x.TaiKhoan,
                MatKhau = x.MatKhau
            }).ToList();
            return Json(result);

        }
        [Route("get_Cus")]
        [HttpGet]
        public IActionResult Getcus()
        {
            var cus = dbc.KhachHangs.Select(x => new
            {
                TenKh = x.TenKh,
                Id = x.Id,
                DiaChi = x.DiaChi,
                Email = x.Email,
                Sdt = x.Sdt,
            }).ToList();
            return Json(cus);
        }

        [Route("checkout")]
        [HttpPost]
        public IActionResult CreateBill([FromBody] CheckoutModel model)
        {
            dbc.KhachHangs.Add(model.kh);
            dbc.SaveChanges();

            int MaKhachHang = model.kh.Id;
            DatPhong dh = new DatPhong();
            dh.Idkh = MaKhachHang;
            dh.Thanhtoan = true;
            dh.Ngaydat = DateTime.Now;
            dbc.DatPhongs.Add(dh);
            dbc.SaveChanges();

            int MaDonHang = dh.Id;

            foreach (var item in model.donhang)
            {
                item.Iddondat = MaDonHang;
                // Xóa navigation property trước khi thêm vào cơ sở dữ liệu
                item.IdpNavigation = null;
                dbc.ChitietDatPhongs.Add(item);
            }
            dbc.SaveChanges();

            return Ok(new { data = "OK" });
        }

        public class CheckoutModel
        {
            public KhachHang kh { get; set; }
            public List<ChitietDatPhong> donhang { get; set; }
        }
        /*Scaffold-DbContext "Server=LAPTOP-LLHPT87U\SQLEXPRESS;Database=API;Trusted_Connection=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force*/
    }
}
