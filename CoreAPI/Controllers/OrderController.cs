using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using CoreAPI.Models.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetCategories")]
        public ActionResult<IEnumerable<FoodCategory>> GetCategories()
        {
            return  _context.FoodCategories.ToList();
        }

       
        [HttpGet]
        [Route("GetFoods/{id}")]
        public ActionResult<IEnumerable<Food>> GetFoods(int id)
        {
            return _context.Foods.Where(f => f.foodCategory_Id == id).ToList();
        }

        [Route("GetAllFoods")]
        public ActionResult<IEnumerable<Food>> GetAllFoods()
        {
            return _context.Foods.Where(f=>f.Stock != 0).ToList();
        }


    }
}
