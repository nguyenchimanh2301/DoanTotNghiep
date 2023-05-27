using Microsoft.AspNetCore.Mvc;
using APIDoanV.Models;
namespace APIDoanV.Controllers
{
    [ApiController]
    public class BillController : Controller
    {
        QuanlyhomestayContext db = new QuanlyhomestayContext();
        [Route("get_all_donhang")]
        [HttpGet]
        public IActionResult Getall()
        {
            var bill = (from t in  db.DatPhongs join
                       p in db.Phongs on t.Idphong equals p.Id  join
                       k in db.KhachHangs on t.Idkh equals k.Id
                       select new
                       {
                           t.Id,
                           p.TenPhong,
                           k.TenKh,
                           t.Ngaydat,
                           t.Ngaytra,
                           t.Thanhtien,
                           t.Thanhtoan
                       }).ToList();

            return Json(bill);
        }
        [Route("get_all_ctdonhang")]
        [HttpGet]
        public IActionResult Getall_ctdh()
        {
            var bill = db.ChitietDatPhongs.ToList();

            return Json(bill);
        }
        [Route("get_chitiet_hoadon")]
        [HttpGet]
        public IActionResult Getall_cthd(int madon)
        {
            var result = (from t in db.DatPhongs join p in db.Phongs on t.Idphong equals p.Id
                          join n in db.ChitietDatPhongs.Where(x=>x.Iddondat==madon) on t.Id equals n.Iddondat
                          select new { t.Id,p.TenPhong,n.Tongthoigiandat,p.Dongia,n.Thanhtien})
                        .ToList();
  

            return Json(result);
        }

    }
}
