using Microsoft.AspNetCore.Mvc;
using APIDoanV.Model;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Controllers
{
    [ApiController]
    public class AccountControllercs : Controller
    {
        QuanlyhomestayContext db = new QuanlyhomestayContext();

        [Route("get_all_account")]
        [HttpGet]
        public IActionResult Get_allAccount()
        {
            var account = db.Accounts.Select(x => new
            {
                MaTaiKhoan = x.MaTaiKhoan,
                TaiKhoan = x.TaiKhoan,
                MatKhau = x.MatKhau,
                anh = x.Anh,
                NgayBatDau = x.NgayBatDau,
                NgayKetThuc = x.NgayKetThuc,
                LoaiQuyen= x.LoaiQuyen,
                TrangThai= x.TrangThai,
                MaNguoiDung= x.Idkh
            });
            return Json(account);
        }
        [Route("get_acc_byid")]
        [HttpGet]
        public IActionResult get_acc_byid(int id)
        {
            var account = db.Accounts.Select(x => new
            {
                MaTaiKhoan = x.MaTaiKhoan,
                TaiKhoan = x.TaiKhoan,
                MatKhau = x.MatKhau,
                anh = x.Anh,

                NgayBatDau = x.NgayBatDau,
                NgayKetThuc = x.NgayKetThuc,
                LoaiQuyen = x.LoaiQuyen,
                TrangThai = x.TrangThai,
                MaNguoiDung = x.Idkh
            }).Where(x=>x.MaTaiKhoan==id).FirstOrDefault();
            return Json(account);
        }
        [Route("add_Account")]
        [HttpPost]
        public void add_Account(Model.Account lsp)
        {
            try
            {
                lsp.IdkhNavigation = null;
                db.Accounts.Add(lsp);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Route("delete_Account")]
        [HttpDelete]
        public void deleteAccount(int maacc)
        {
            try
            {
                Model.Account ac = db.Accounts.Where(x => x.MaTaiKhoan == maacc).FirstOrDefault();
                db.Accounts.Remove(ac);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Route("update_Account")]
        [HttpGet]
        public void update_Account(Model.Account ac)
        {
            try
            {
                ac.IdkhNavigation = null;
                db.Accounts.Attach(ac);
                db.Entry(ac).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Route("Search_Account")]
        [HttpGet]
        public IActionResult search_Account(string lq)
        {
            try
            {
                var c = db.Accounts.Select(x => x.LoaiQuyen == lq).ToList();
                return Json(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Route("dangki")]
        [HttpPost]
        public IActionResult CreateBill([FromBody] DangKi model)
        {
            db.KhachHangs.Add(model.kh);
            db.SaveChanges();
            int MaKhachHang = model.kh.Id;
            model.ac.Idkh = MaKhachHang;
            model.ac.LoaiQuyen = "user";
            model.ac.TrangThai = false;
            model.ac.IdkhNavigation = null;
            // Xóa navigation property trước khi thêm vào cơ sở dữ liệu
            db.Accounts.Add(model.ac);
            db.SaveChanges();

            return Ok(new { data = "OK" });
        }
    }

    public class DangKi 
    {
        public KhachHang kh { get; set; }
        public Account ac { get; set; }
    }

}
