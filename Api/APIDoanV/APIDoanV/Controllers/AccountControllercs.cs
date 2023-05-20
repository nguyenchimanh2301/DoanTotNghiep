using Microsoft.AspNetCore.Mvc;
using APIDoanV.Models;
namespace APIDoanV.Controllers
{
    [ApiController]
    public class AccountControllercs : Controller
    {
        ApiContext db = new ApiContext();
        [Route("get_all_account")]
        [HttpGet]
        public IActionResult Get_allAccount()
        {
            var account = db.Accounts.Select(x => new
            {
                MaTaiKhoan = x.MaTaiKhoan,
                TaiKhoan = x.TaiKhoan,
                MatKhau = x.MatKhau,
                NgayBatDau= x.NgayBatDau,
                NgayKetThuc = x.NgayKetThuc,
                LoaiQuyen= x.LoaiQuyen,
                TrangThai= x.TrangThai,
                MaNguoiDung= x.MaNguoiDung
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
                NgayBatDau = x.NgayBatDau,
                NgayKetThuc = x.NgayKetThuc,
                LoaiQuyen = x.LoaiQuyen,
                TrangThai = x.TrangThai,
                MaNguoiDung = x.MaNguoiDung
            }).Where(x=>x.MaTaiKhoan==id).FirstOrDefault();
            return Json(account);
        }
        [Route("add_Account")]
        [HttpGet]
        public void add_Account(Account lsp)
        {
            try
            {
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
        public void deleteCategory(int maacc)
        {
            try
            {
                Account ac = db.Accounts.Where(x => x.MaTaiKhoan == maacc).FirstOrDefault();
                db.Accounts.Remove(ac);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
