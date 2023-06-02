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
        [Route("add_bill")]
        [HttpPost]
        public void postbill(DatPhong dp)
        {

            dbc.DatPhongs.Add(dp);
            dbc.SaveChanges();
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
            model.datphong.Idkh = MaKhachHang;
            model.datphong.Tenkh = model.kh.TenKh;
            model.datphong.Thanhtoan = true;
                model.datphong.IdkhNavigation = null;
                dbc.DatPhongs.Add(model.datphong);
                dbc.SaveChanges();
                int MaDonHang = model.datphong.Id;
                model.donhang.Iddondat = MaDonHang;
                // Xóa navigation property trước khi thêm vào cơ sở dữ liệu
                model.donhang.IdpNavigation = null;
                dbc.ChitietDatPhongs.Add(model.donhang);
                dbc.SaveChanges();
           
            return Ok(new { data = "OK" });
        }

        public class CheckoutModel
        {
            public KhachHang kh { get; set; }
            public ChitietDatPhong donhang { get; set; }
            public DatPhong datphong { get; set; }

        }
        /*Scaffold-DbContext "Server=LAPTOP-LLHPT87U\SQLEXPRESS;Database=QUANLYHOMESTAY;Trusted_Connection=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Model -force*/
    }
}
