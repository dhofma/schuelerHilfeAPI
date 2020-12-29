using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SchülerHelfenSchüler.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase {   
        [HttpPost, DisableRequestSizeLimit]
        public async IActionResult Upload() {
            try {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if(file.Length < 0) {
                    var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, filename);
                    var 
                }
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        
    }
}
