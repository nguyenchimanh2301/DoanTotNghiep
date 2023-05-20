using Microsoft.AspNetCore.Mvc;
using APIDoanV.Model;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Web.Http;
namespace APIDoanV.Controllers
{
    [ApiController]
    public class HomeStayController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Không có tệp tin được chọn hoặc tệp tin trống.");
            }

            var uploadFolder = "path/to/destination/folder";
            var filePath = Path.Combine(uploadFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("Upload thành công!");
        }
        /* private readonly string _uploadFolder;
         public HomeStayController()
         {
             // Đường dẫn tuyệt đối đến thư mục upload
             _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "C:/Users/ASUS/Desktop/Admin-master/src/assets/Homestay");
         }
         [Route("uploadfile")]
         [HttpPost]
         public IActionResult UploadImage(IFormFile file)
         {
             try
             {
                 // Tạo đường dẫn đến tệp ảnh trong thư mục upload
                 var filePath = Path.Combine(_uploadFolder, file.FileName);

                 // Di chuyển tệp ảnh vào thư mục upload
                 using (var fileStream = new FileStream(filePath, FileMode.Create))
                 {
                     file.CopyTo(fileStream);
                 }

                 return Ok("Tải lên thành công!");
             }
             catch (Exception ex)
             {
                 return StatusCode(StatusCodes.Status500InternalServerError, $"Lỗi khi tải lên: {ex.Message}");
             }
         }
 */
        QuanlyhomestayContext db = new QuanlyhomestayContext();
        [Route("get_all_homestay")]
        [HttpGet]
        public ActionResult Get_all_Product()
        {
            var obj = db.Phongs.Select(sp => new
            {
              id = sp.Id,
              idloai = sp.IdloaiPhong,
              ten = sp.TenPhong,
              anh = sp.Anh,
              gia = sp.Dongia,
              trangthai = sp.Trangthai
            }).ToList();
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
                db.Phongs.Remove(sp);
                db.SaveChanges();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Route("Search_Homstay")]
        [HttpGet]
        public IActionResult Search(string name)
        {
           
                if (string.IsNullOrEmpty(name))
                {
                    var obj = db.Phongs.Select(sp => new
                    {
                        id = sp.Id,
                        idloai = sp.IdloaiPhong,
                        ten = sp.TenPhong,
                        anh = sp.Anh,
                        gia = sp.Dongia,
                        trangthai = sp.Trangthai

                    }).ToList();
                    return Json(obj);
                }
                else
                {
                    var obj = db.Phongs.Select(sp => new
                    {
                        id = sp.Id,
                        idloai = sp.IdloaiPhong,
                        ten = sp.TenPhong,
                        anh = sp.Anh,
                        gia = sp.Dongia,
                        trangthai = sp.Trangthai

                    }).Where(x => x.ten.Contains(name)).ToList();
                    return Json(obj);

                }
            }

    }
}
