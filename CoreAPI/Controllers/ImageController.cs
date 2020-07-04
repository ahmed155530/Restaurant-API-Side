using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CoreAPI.Models;
using CoreAPI.Models.Classes;
using CoreAPI.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        //for image
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        //private readonly IHostingEnvironment host;

        public ImageController(ApplicationDbContext context )
        {
            _context = context;
           // this.host = host;
        }

        //[HttpPost]
        //[Route("Upload")]
        //public async Task<IActionResult> Upload([FromForm]FoodImageViewModel filesData)
        //{
        //    Food food = new Food()
        //    {
        //        Name = filesData.Name ,
        //    };
        //    if (filesData.TileImage == null) return BadRequest("Null File");
        //    if (filesData.TileImage.Length == 0)
        //    {
        //        return BadRequest("Empty File");
        //    }
        //    if (filesData.TileImage.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
        //    if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.TileImage.FileName).ToLower())) return BadRequest("Invalid file type.");
        //    var uploadFilesPath = Path.Combine("Resources", "Food", "Images");
        //    if (!Directory.Exists(uploadFilesPath))
        //        Directory.CreateDirectory(uploadFilesPath);
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.TileImage.FileName);
        //    var filePath = Path.Combine(uploadFilesPath, fileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await filesData.TileImage.CopyToAsync(stream);
        //    }
        //    var photo = new Image { Path = fileName };
        //    _context.Images.Add(photo);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}



    }
}
