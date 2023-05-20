using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using APIDoanV.Models;

namespace APIDoanV.Controllers
{
    [ApiController]
    public class CustomerController : Controller
    {
        ApiContext db = new ApiContext();
        [Route("getacc")]
        [HttpGet]
        public IActionResult Getuser()
        {
            var result = db.Accounts.Select(x => new
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
            var cus = db.KhachHangs.Select(x => new
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
        public IActionResult Createbill([FromBody] checkout model)
        {
            
                model.kh.Id = Guid.NewGuid().ToString();
                db.KhachHangs.Add(model.kh);
                db.SaveChanges();
                string MaKhachHang = model.kh.Id;
                Donhang dh = new Donhang();
                dh.MaKhachHang = MaKhachHang;
                dh.Trangthai = "ok";
                dh.Ngaydat = DateTime.Now;
                db.Donhangs.Add(dh);
                db.SaveChanges();
                int MaDonHang = dh.MaDonHang;

                if (model.donhang.Count > 0)
                {
                    foreach (var item in model.donhang)
                    {
                        item.MaDonHang = MaDonHang;
                        db.ChiTietDonHangs.Add(item);
                    }
                    db.SaveChanges();
                }
                return Ok(new { data = "OK" });
            }
         
        }
    public class checkout
    {
        public KhachHang kh { get; set; }
        public List<ChiTietDonHang>donhang { get; set; }
    }
    /*Scaffold-DbContext "Server=LAPTOP-LLHPT87U\SQLEXPRESS;Database=API;Trusted_Connection=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force*/
}
