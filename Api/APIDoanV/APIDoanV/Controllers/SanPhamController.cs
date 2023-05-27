using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using APIDoanV.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Controllers
{
    [ApiController]

    public class SanPhamController : Controller
    {

        /*ApiContext db = new ApiContext();
        [Route("getall")]
        [HttpGet]
        public ActionResult Get_all_Product()
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                DonViTinh = sp.DonViTinh,
                MotaSp = sp.MotaSp,
            }).Take(8).ToList();
            return Json(obj);
        }
        [Route("get_gia")]
        [HttpGet]
        public ActionResult Get_product()
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                DonViTinh = sp.DonViTinh,
                MotaSp = sp.MotaSp,
            }).OrderByDescending(x=>x.unit_price).Take(8).ToList();
            return Json(obj);
        }
        [Route("moi_nhat")]
        [HttpGet]
        public ActionResult Get_product_date()
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                DonViTinh = sp.DonViTinh,
                MotaSp = sp.MotaSp,
            }).OrderByDescending(x => x.NgaySanxuat).Take(8).ToList();
            return Json(obj);
        }
        [Route("get_by_id")]
        [HttpGet]
        public ActionResult Getid(string id)
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                MotaSp = sp.MotaSp,
                DonViTinh = sp.DonViTinh
            }).Where(x => x.id == id).FirstOrDefault();
            return Json(obj);
        }
        [Route("get_list_product")]
        [HttpGet]
        public ActionResult Get_list_Product()
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                MotaSp = sp.MotaSp,
                DonViTinh = sp.DonViTinh

            }).ToList();
            return Json(obj);
        }
        [Route("get_cung_loai")]
        [HttpGet]
        public ActionResult Get_cungloai(string id_lsp)
        {
            var obj = db.SanPhams.Select(sp => new
            {
                id = sp.Id.Trim(),
                name = sp.Name,
                id_loai_sp = sp.IdLoaiSp,
                unit_price = sp.UnitPrice,
                so_luong = sp.SoLuong,
                image = sp.Image,
                HanSudung = sp.HanSudung,
                NgaySanxuat = sp.NgaySanxuat,
                MotaSp = sp.MotaSp,
                DonViTinh = sp.DonViTinh

            }).Where(x=>x.id_loai_sp==id_lsp).ToList();
            return Json(obj);
        }
        [Route("add_Sp")]
        [HttpPost]
        public void addSP(SanPham sp)
        {

            try
            {
                Random rnd = new Random();
                for (int j = 0; j < 4; j++)
                {
                    sp.Id = "SP" + rnd.Next().ToString();
                }
                sp.NgayThem = DateTime.Now;
                db.SanPhams.Add(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("update_Sp")]
        [HttpPut]
        public void updateSP(SanPham sp)
        {

            try
            {
                sp.NgayThem = DateTime.Now;
                db.SanPhams.Attach(sp);
                db.Entry(sp).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Delete_Sp")]
        [HttpDelete]
        public void DeleteSP(string id)
        {
            try
            {
                SanPham sp = db.SanPhams.FirstOrDefault(sp => sp.Id == id);
                db.SanPhams.Remove(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Search")]
        [HttpGet]
        public IActionResult Search(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    var obj = db.SanPhams.Select(sp => new
                    {
                        id = sp.Id.Trim(),
                        name = sp.Name,
                        id_loai_sp = sp.IdLoaiSp,
                        unit_price = sp.UnitPrice,
                        so_luong = sp.SoLuong,
                        image = sp.Image,
                        HanSudung = sp.HanSudung,
                        NgaySanxuat = sp.NgaySanxuat,

                    }).ToList();
                    return Json(obj);
                }
                else
                {
                    var obj = db.SanPhams.Select(sp => new
                    {
                        id = sp.Id.Trim(),
                        name = sp.Name,
                        id_loai_sp = sp.IdLoaiSp,
                        unit_price = sp.UnitPrice,
                        so_luong = sp.SoLuong,
                        image = sp.Image,
                        HanSudung = sp.HanSudung,
                        NgaySanxuat = sp.NgaySanxuat,
                    }).Where(x => x.name.Contains(name)).ToList();
                    return Json(obj);

                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        [Route("Search_by_idcategory")]
        [HttpGet]
        public IActionResult Search_id_category(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    var obj = db.SanPhams.Select(sp => new
                    {
                        id = sp.Id.Trim(),
                        name = sp.Name,
                        id_loai_sp = sp.IdLoaiSp,
                        unit_price = sp.UnitPrice,
                        so_luong = sp.SoLuong,
                        image = sp.Image,
                        HanSudung = sp.HanSudung,
                        NgaySanxuat = sp.NgaySanxuat,

                    }).ToList();
                    return Json(obj);
                }
                else
                {
                    var obj = db.SanPhams.Select(sp => new
                    {
                        id = sp.Id.Trim(),
                        name = sp.Name,
                        id_loai_sp = sp.IdLoaiSp,
                        unit_price = sp.UnitPrice,
                        so_luong = sp.SoLuong,
                        image = sp.Image,
                        HanSudung = sp.HanSudung,
                        NgaySanxuat = sp.NgaySanxuat,
                    }).Where(x => x.id_loai_sp==id).ToList();
                    return Json(obj);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }*/
    }
}
