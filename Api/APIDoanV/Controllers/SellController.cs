using Microsoft.AspNetCore.Mvc;
using APIDoanV.Models;
using System.Linq;
using System.Collections.Generic;
using APIDoanV.Entities;
using System;
using Microsoft.AspNetCore.Authorization;

namespace APIDoanV.Controllers
{
    [ApiController]
    public class SellController : Controller
    {
       /* private ApiContext db = new ApiContext();
        [Route("create-hoadonban")]
        [HttpPost]

        public IActionResult CreateItem([FromBody] Hoadonbancs model)
        {
          
            model.khach.Id = Guid.NewGuid().ToString();
            db.KhachHangs.Add(model.khach);
            db.SaveChanges();
            string MaKhachHang = model.khach.Id;
            BillsBan dh = new BillsBan();
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                dh.IdBillBan = random.Next();
            }
            dh.IdKh = MaKhachHang;
            dh.NgayBan = System.DateTime.Now;
            db.BillsBans.Add(dh);
            int MaHoaDonBan = dh.IdBillBan;
            db.SaveChanges();
            if (model.chitiethoadonban.Count > 0)
            { 
                foreach (var item in model.chitiethoadonban)
                {
                    item.IdBillBan = MaHoaDonBan;
                    db.BillDetailBans.Add(item);
                    *//*var obj = db.ChiTietKhos.SingleOrDefault(x => x.MaSanPham == item.MaSanPham);
                    obj.SoLuong = obj.SoLuong - item.SoLuong;*//*
                }
                db.SaveChanges();
            }

            return Ok(new { data = "OK" });
        }
        [Route("get_hoadonban")]
        [HttpGet]
        public IActionResult getbill()
        {
            var result = (from t in db.KhachHangs
                          join n in db.BillsBans on t.Id equals n.IdKh
                          select new { t.TenKh, n.IdBillBan, t.DiaChi, n.NgayBan })
                          .ToList();
            return Json(result);
        }
        [Route("get_chitiethoadonban")]
        [HttpGet]
        public IActionResult get_chitiethdb(int id)
        {
            var result = (from t in db.BillsBans
                          join n in db.BillDetailBans on t.IdBillBan equals n.IdBillBan 
                          join s in db.SanPhams on n.Masp equals s.Id
                          where t.IdBillBan == n.IdBillBan 
                          select new {n.IdBillBan,n.Id, s.Name,n.Soluong,n.Giaban }).Where(x=>x.IdBillBan == id).ToList();
            return Json(result);
        }*/
    }
 
}
