using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/word")]
public class WordController : ControllerBase
{
    [HttpPost]
    public IActionResult GenerateWordDocument([FromBody] HtmlData htmlData)
    {
        // Kiểm tra dữ liệu HTML
        if (string.IsNullOrEmpty(htmlData?.HtmlContent))
        {
            return BadRequest("Dữ liệu HTML không hợp lệ.");
        }

        // Tạo tên file output
        string fileName = "output.docx";

        // Tạo đường dẫn đầy đủ cho file output
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        // Tạo tài liệu Word mới và ghi HTML vào tài liệu
        using (WordprocessingDocument doc = WordprocessingDocument.Create(outputPath, WordprocessingDocumentType.Document))
        {
            MainDocumentPart mainPart = doc.AddMainDocumentPart();
            mainPart.Document = new Document();
            Body body = new Body();
            Paragraph paragraph = new Paragraph();
            Run run = new Run();
            run.Append(new Text(htmlData.HtmlContent));

            paragraph.Append(run);
            body.Append(paragraph);
            mainPart.Document.Append(body);

            doc.Save();
        }

        // Trả về file Word đã tạo
        return File(System.IO.File.ReadAllBytes(outputPath), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", fileName);
    }
    public class HtmlData
    {
        public string HtmlContent { get; set; }
    }

}
