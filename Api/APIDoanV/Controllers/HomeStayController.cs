using APIDoanV.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace APIDoanV.Controllers
{
  [ApiController]
  public class HomeStayController : Controller
  {

    QuanlyhomestayContext db = new QuanlyhomestayContext();
    [Route("get_all_homestay")]
    [HttpGet]
    public ActionResult Get_all_Product()
    {
      var obj = (from sp in db.Phongs
                 join
                l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                 select new
                 {
                   sp.Id,
                   l.TenLoaiPhong,
                   sp.IdloaiPhong,
                   sp.TenPhong,
                   sp.Anh,
                   sp.Dongia,
                   sp.Trangthai
                 });
      return Json(obj);
    }
    [Route("get_all_homestay_by_idloai")]
    [HttpGet]
    public ActionResult Getallhomestayby_idloai(int id)
    {
      var obj = (from sp in db.Phongs
                 join
                     l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                 select new
                 {
                   sp.Id,
                   l.TenLoaiPhong,
                   sp.IdloaiPhong,
                   sp.TenPhong,
                   sp.Anh,
                   sp.Dongia,
                   sp.Trangthai
                 }).Where(x => x.IdloaiPhong == id);
      return Json(obj);
    }
    [Route("getht_by_id")]
    [HttpGet]
    public ActionResult Getid(int id)
    {
      var obj = db.Phongs.Select(sp => new
      {
        id = sp.Id,
        idloai = sp.IdloaiPhong,
        ten = sp.TenPhong,
        anh = sp.Anh,
        gia = sp.Dongia,
      }).Where(x => x.id == id).FirstOrDefault();
      return Json(obj);
    }
    [Route("add_homestay")]
    [HttpPost]
    public void add(Phong sp)
    {

      try
      {
        sp.IdloaiPhongNavigation = null;
        db.Phongs.Add(sp);
        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("update_homestay")]
    [HttpPut]
    public void update(Phong sp)
    {

      try
      {
        sp.IdloaiPhongNavigation = null;
        db.Phongs.Attach(sp);
        db.Entry(sp).State = EntityState.Modified;
        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("Delete_homestay")]
    [HttpDelete]
    public void Delete(int id)
    {
      try
      {
        var sp = db.Phongs.FirstOrDefault(sp => sp.Id == id);
         var p = db.ChitietDatPhongs.FirstOrDefault(x => x.Idp == id);
                if (p != null)
                {
                    db.ChitietDatPhongs.Remove(p);
                    db.SaveChanges();
                    db.Phongs.Remove(sp);
                }
                else
                {
                    db.Phongs.Remove(sp);

                }

        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("Search_Homstay")]
    [HttpGet]
    public IActionResult Search(string? name,int? idloai)
    {

      if (name==null && idloai==null)
      {
        var obj = (from sp in db.Phongs
                   join
         l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                   select new
                   {
                     sp.Id,
                     l.TenLoaiPhong,
                     sp.IdloaiPhong,
                     sp.TenPhong,
                     sp.Anh,
                     sp.Dongia,
                     sp.Trangthai
                   });
        return Json(obj);
      }
      else if (name == null && idloai != null)
            {
                var obj = (from sp in db.Phongs
                           join
                 l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                           select new
                           {
                               sp.Id,
                               l.TenLoaiPhong,
                               sp.IdloaiPhong,
                               sp.TenPhong,
                               sp.Anh,
                               sp.Dongia,
                               sp.Trangthai
                           }).Where(x =>x.IdloaiPhong == idloai);
                return Json(obj);
            }
            else if (name != null && idloai == null)
            {
                var obj = (from sp in db.Phongs
                           join
                 l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                           select new
                           {
                               sp.Id,
                               l.TenLoaiPhong,
                               sp.IdloaiPhong,
                               sp.TenPhong,
                               sp.Anh,
                               sp.Dongia,
                               sp.Trangthai
                           }).Where(x=>x.TenPhong.ToLower().Contains(name.ToLower()));
                return Json(obj);
            }
            else
        {
          var obj = (from sp in db.Phongs
                     join
                l in db.LoaiPhongs on sp.IdloaiPhong equals l.Id
                     select new
                     {
                       sp.Id,
                       l.TenLoaiPhong,
                       sp.IdloaiPhong,
                       sp.TenPhong,
                       sp.Anh,
                       sp.Dongia,
                       sp.Trangthai
                     }).Where(x => x.TenPhong.ToLower().Contains(name.ToLower()) && x.IdloaiPhong==idloai);
          return Json(obj);

        }

    }
  }
}
