using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace MyAPI.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        FileExtensionContentTypeProvider FileExtensionContentTypeProvider;
        public FilesController(FileExtensionContentTypeProvider fileExtensionContentType)
        {
            FileExtensionContentTypeProvider= fileExtensionContentType;
        }
        [HttpGet("code")]
        public ActionResult GetFile(string code)
        {
            string path= "کدنویسی مطمئن، تکنیک_های امنیت داده برای برنامه_نویسان وب.pdf";
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            if (FileExtensionContentTypeProvider.TryGetContentType(path,out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes=System.IO.File.ReadAllBytes(path);
            return File(bytes, contentType, Path.GetFileName(path));
        }
    }
}
