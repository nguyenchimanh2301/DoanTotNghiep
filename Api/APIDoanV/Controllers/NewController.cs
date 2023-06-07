using APIDoanV.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Controllers
{
    [ApiController]
    public class NewController : Controller
    {
        QuanlyhomestayContext db = new QuanlyhomestayContext();
        [Route("get_all_baiviet")]
        [HttpGet]
        public ActionResult Get_all_Product()
        {
            var obj = db.Baiviets.Select(sp => new
            {
                 sp.Idbaiviet,
                 sp.Iduser,
                 sp.Anh,
                 sp.Tieude,
                sp.Noidung,
                sp.Ngaydangbai,
            }).ToList();
            return Json(obj);
        }
        [Route("getbv_by_id")]
        [HttpGet]
        public ActionResult Getid(int id)
        {
            var obj = db.Baiviets.Select(sp => new
            {
                sp.Idbaiviet,
                sp.Iduser,
                sp.Anh,
                sp.Tieude,
                sp.Noidung,
                sp.Ngaydangbai,
            }).Where(x => x.Idbaiviet == id).FirstOrDefault();
            return Json(obj);
        }
        [Route("add_baiviet")]
        [HttpPost]
        public void add(Baiviet sp)
        {

            try
            {
                db.Baiviets.Add(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("update_baiviet")]
        [HttpPut]
        public void update(Baiviet sp)
        {

            try
            {
                db.Baiviets.Attach(sp);
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Delete_baiviet")]
        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                var sp = db.Baiviets.FirstOrDefault(sp => sp.Idbaiviet == id);
                db.Baiviets.Remove(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Search_baiviet")]
        [HttpGet]
        public IActionResult Search(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                var obj = db.Baiviets.Select(sp => new
                {
                    sp.Idbaiviet,
                    sp.Iduser,
                    sp.Anh,
                    sp.Tieude,
                    sp.Noidung,
                    sp.Ngaydangbai,
                }).ToList();
                return Json(obj);
            }
            else
            {
                var obj = db.Baiviets.Select(sp => new
                {
                    sp.Idbaiviet,
                    sp.Iduser,
                    sp.Anh,
                    sp.Tieude,
                    sp.Noidung,
                    sp.Ngaydangbai,
                }).Where(x => x.Tieude.Contains(name)).ToList();
                return Json(obj);

            }
        }
    }
}
