using System.IO;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        [HttpPost]
        public JsonResult UploadByAjax()
        {
            //取得目前 HTTP 要求的 HttpRequestBase 物件
            foreach (string file in Request.Files)
            {
                var fileContent = Request.Files[file];
                if (fileContent != null && fileContent.ContentLength > 0)
                {
                    // 取得的檔案是stream
                    var stream = fileContent.InputStream;
                    var fileName = Path.GetFileName(file);
                    var path = Path.Combine(Server.MapPath("~/Files/"), fileName);
                    using (var fileStream = System.IO.File.Create(path))
                    {
                        stream.CopyTo(fileStream);
                    }
                }
            }

            return Json("Successed");
        }
    }
}