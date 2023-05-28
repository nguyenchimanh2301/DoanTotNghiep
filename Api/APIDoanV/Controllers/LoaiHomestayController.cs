using APIDoanV.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Controllers
{
    [ApiController]
    public class LoaiHomestayController : Controller
    {
        QuanlyhomestayContext db = new QuanlyhomestayContext();
        [Route("get_all_loaihomestay")]
        [HttpGet]
        public IActionResult Get_all_loaihomstay()
        {
            var obj = db.LoaiPhongs.Select(sp => new
            {
                id = sp.Id,
                tenloai = sp.TenLoaiPhong
            }).ToList();
            return Json(obj);
        }
        [Route("get_loaihomestay_id")]
        [HttpGet]
        public IActionResult Getbyid(int id)
        {
            var obj = db.LoaiPhongs.Select(sp => new
            {
                id = sp.Id,
                tenloai = sp.TenLoaiPhong
            }).Where(x => x.id == id).First();
            return Json(obj);
        }
        [Route("add_loaihomestay")]
        [HttpPost]
        public void add(LoaiPhong sp)
        {

            try
            {
                db.LoaiPhongs.Add(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("update_loaihomestay")]
        [HttpPut]
        public void update(LoaiPhong sp)
        {

            try
            {
                db.LoaiPhongs.Attach(sp);
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Delete_loaihomestay")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                var sp = db.LoaiPhongs.FirstOrDefault(sp => sp.Id == id);
                db.LoaiPhongs.Remove(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Search_LoaiHomstay")]
        [HttpGet]
        public IActionResult Search(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                var obj = db.LoaiPhongs.Select(sp => new
                {
                    id = sp.Id,
                    tenloai = sp.TenLoaiPhong
                }).ToList();
                return Json(obj);
            }
            else
            {
                var obj = db.LoaiPhongs.Select(sp => new
                {
                    id = sp.Id,
                    tenloai = sp.TenLoaiPhong
                }).Where(x => x.tenloai.Contains(name)).ToList();
                return Json(obj);

            }
        }
    }
}
