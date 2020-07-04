using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI.Data;
using CoreAPI.Models.Classes;
using CoreAPI.Models;
using System.IO;
using System.Net.Http.Headers;
using CoreAPI.ViewModels;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };
        public FoodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Food
        [HttpGet]
        public ActionResult<List<Food>> GetFood()
         {
            return _context.Foods.ToList();
        }

        // GET: api/Food/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Food>> GetFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            food.reviews = _context.Reviews.Where(r => r.food_Id == id).ToList();
            if (food == null)
            {
                return NotFound();
            }
            return food;
        }

        // PUT: api/Food/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }

            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Food
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Food>> PostFood(Food food)
        //{
        //    _context.Foods.Add(food);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetFood", new { id = food.Id }, food);
        //}

        // DELETE: api/Food/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Food>> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }





        [HttpPost]
        [Route("PostFood")]
        public async Task<IActionResult> PostFood([FromForm] FoodImageViewModel filesData)
        {
            Food food = new Food()
            {
                Name = filesData.Name,
                Price = filesData.Price , 
                Stock = filesData.Stock , 
                foodCategory_Id = filesData.foodCategory_Id ,                
            };
            if (filesData.image == null) return BadRequest("Null File");
            if (filesData.image.Length == 0)
            {
                return BadRequest("Empty File");
            }
            if (filesData.image.Length > 10 * 1024 * 1024) return BadRequest("Max file size exceeded.");
            if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(filesData.image.FileName).ToLower())) return BadRequest("Invalid file type.");
            var uploadFilesPath = Path.Combine("Resources", "Food", "Images");
            if (!Directory.Exists(uploadFilesPath))
                Directory.CreateDirectory(uploadFilesPath);
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(filesData.image.FileName);
            var filePath = Path.Combine(uploadFilesPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await filesData.image.CopyToAsync(stream);
            }

            Image photo = new Image()
            {
                Path = fileName,
                food_Id = food.Id
            };
            _context.Images.Add(photo);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        [Route("GetImage/{id}")]

        public async Task<dynamic> GetImage(int id)
        {
            var data = await _context.Images.Where(i => i.Id == id).FirstOrDefaultAsync();

            string name = data.Path;
            byte[] str = data.ImageData;

            byte[] result = System.IO.File.ReadAllBytes(name);
            var stream = new MemoryStream();
            byte[] res = stream.ToArray();
            return new { Image = result };
        }

        //public string GetImage()
        //{
        //    var path = Path.Combine("Resources", "Food", "Images").Where();
        //    return path;
        //}

    }
}
