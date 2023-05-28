using Microsoft.AspNetCore.Mvc;
using APIDoanV.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Web.Http;
namespace APIDoanV.Controllers
{
  [ApiController]
  public class NhanVienController : Controller
  {
    QuanlyhomestayContext db = new QuanlyhomestayContext();
    [Route("get_all_nhanvien")]
    [HttpGet]
    public ActionResult Get_all_Product()
    {
      var obj = db.NhanViens.Select(sp => new
      {
        id = sp.Username,
        idloai = sp.Password,
        ten = sp.HoVaTen,
        anh = sp.DiaChi,
        gia = sp.ChucVu,
        trangthai = sp.DienThoai
      }).ToList();
      return Json(obj);
    }
    [Route("getnv_by_id")]
    [HttpGet]
    public ActionResult Getid(string id)
    {
      var obj = db.NhanViens.Select(sp => new
      {
        id = sp.Username,
        idloai = sp.Password,
        ten = sp.HoVaTen,
        anh = sp.DiaChi,
        gia = sp.ChucVu,
        trangthai = sp.DienThoai
      }).Where(x => x.id == id).FirstOrDefault();
      return Json(obj);
    }
    [Route("add_nhanvien")]
    [HttpPost]
    public void add(NhanVien sp)
    {

      try
      {
        db.NhanViens.Add(sp);
        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("update_nhanvien")]
    [HttpPut]
    public void update(NhanVien sp)
    {

      try
      {
        db.NhanViens.Attach(sp);
        db.Entry(sp).State = EntityState.Modified;
        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("Delete_nhanvien")]
    [HttpDelete]
    public void Delete(string id)
    {
      try
      {
        var sp = db.NhanViens.FirstOrDefault(sp => sp.Username == id);
        db.NhanViens.Remove(sp);
        db.SaveChanges();
      }
      catch (Exception e)
      {

        throw e;
      }
    }
    [Route("Search_nhanvien")]
    [HttpGet]
    public IActionResult Search(string name)
    {

      if (string.IsNullOrEmpty(name))
      {
        var obj = db.NhanViens.Select(sp => new
        {
          id = sp.Username,
          idloai = sp.Password,
          ten = sp.HoVaTen,
          anh = sp.DiaChi,
          gia = sp.ChucVu,
          trangthai = sp.DienThoai
        }).ToList();
        return Json(obj);
      }
      else
      {
        var obj = db.NhanViens.Select(sp => new
        {
          id = sp.Username,
          idloai = sp.Password,
          ten = sp.HoVaTen,
          anh = sp.DiaChi,
          gia = sp.ChucVu,
          trangthai = sp.DienThoai
        }).Where(x => x.ten.Contains(name)).ToList();
        return Json(obj);

      }
    }
  }
}
