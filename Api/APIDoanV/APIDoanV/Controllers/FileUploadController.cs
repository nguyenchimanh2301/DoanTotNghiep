using Microsoft.AspNetCore.Mvc;

namespace APIDoanV.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FileUploadController : Controller
  {
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
      if (file == null || file.Length == 0)
      {
        return BadRequest("No file uploaded.");
      }

      // Đường dẫn tới thư mục lưu trữ file
      string folderPath = "C:/Users/ASUS/Desktop/Admin-master/src/assets/Homestay";

      // Tạo đường dẫn tới file
      string filePath = Path.Combine(folderPath, file.FileName);

      // Kiểm tra thư mục lưu trữ file đã tồn tại chưa, nếu chưa thì tạo mới
      if (!Directory.Exists(folderPath))
      {
        Directory.CreateDirectory(folderPath);
      }

      // Lưu file vào thư mục
      using (var stream = new FileStream(filePath, FileMode.Create))
      {
        await file.CopyToAsync(stream);
      }

      return Ok("File uploaded successfully!");
    }
  }
}
    /* [Route("uploadfile")]
    [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Không có tệp tin được chọn hoặc tệp tin trống.");
            }

            var uploadFolder = "C:/Users/ASUS/Desktop/Admin-master/src/assets/Homestay";
            var filePath = Path.Combine(uploadFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok("Upload thành công!");
        }*/
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
}
}*/

