﻿using Microsoft.AspNetCore.Mvc;
using APIDoanV.Model;
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
            var bill = (from kh in db.KhachHangs join  t in  db.DatPhongs on kh.Id equals t.Idkh join c in db.ChitietDatPhongs 
                       on t.Id equals c.Iddondat join
                       p in db.Phongs on c.Idp  equals p.Id
                       select new
                       {
                           t.Id,
                           p.TenPhong,
                           kh.TenKh,
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
            var result = (from t in db.DatPhongs join p in db.ChitietDatPhongs.Where(x=>x.Iddondat==madon) on t.Id equals p.Iddondat
                          join n in db.Phongs on p.Idp equals n.Id
                          select new { t.Id,n.TenPhong,p.Tongthoigiandat,p.Dongia,p.Thanhtien})
                        .ToList();
  

            return Json(result);
        }

    }
}
