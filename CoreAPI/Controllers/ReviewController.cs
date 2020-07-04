using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Models;
using CoreAPI.Models.Classes;
using CoreAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("getReviewsForCustomer")]
        public List<ReviewFoodViewModel> getReviewsForCustomer(Customer cust)
        {
            List<Food_Order> food_Orders = _context.Food_Orders.Where(m => m.booking.customer_Id == cust.UserId).ToList();
            List<int> foodIdslist = new List<int>();
            foreach (var item in food_Orders)
            {
                foodIdslist.Add(item.food_Id.Value);
            }
            List<int> uniquefoodList = (from t in foodIdslist
                                        group t by t into nGroup
                                        where nGroup.Count() >= 1
                                        select nGroup.Key).ToList();
            List<ReviewFoodViewModel> reviews = new List<ReviewFoodViewModel>();
            foreach (var item in uniquefoodList)
            {
                ReviewFoodViewModel model = new ReviewFoodViewModel();
                model.foodName = _context.Foods.Where(n => n.Id == item).Select(n => n.Name).FirstOrDefault();
                model.food_Id = _context.Foods.Where(n => n.Id == item).Select(n => n.Id).FirstOrDefault();
                model.reviewContent = _context.Reviews.Where(r => r.customer_Id == cust.UserId && r.food_Id == item).Select(r=>r.ReviewContent).FirstOrDefault();
                model.postingDate = _context.Reviews.Where(r => r.customer_Id == cust.UserId && r.food_Id == item).Select(r => r.PostingDate).FirstOrDefault();
                model.id = _context.Reviews.Where(r => r.customer_Id == cust.UserId && r.food_Id == item).Select(r => r.Id).FirstOrDefault();
                
                reviews.Add(model);
            }
            return reviews;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Review>> getReviews(int id)
        {
            return _context.Reviews.Where(r => r.food_Id == id).ToList();
        }

        [HttpPost]
        [Route("postReview")]
        public string postReview(Review review)
        {
            if(review.ReviewContent == null || review.ReviewContent == "")
            {
                return "Content is Empty";
            }
            else
            {
                Review previousReview = _context.Reviews.Where(r => (r.food_Id == review.food_Id && r.customer_Id == review.customer_Id)).FirstOrDefault();
                if(previousReview == null)
                {
                    Review newReview = new Review()
                    {
                        PostingDate = review.PostingDate,
                        ReviewContent = review.ReviewContent,
                        food_Id = review.food_Id , 
                        customer_Id = review.customer_Id
                    };
                    _context.Reviews.Add(newReview);
                    _context.SaveChanges();
                    return "Review is posted Successfully!";
                }
                else
                {
                    previousReview.PostingDate = DateTime.Now;
                    previousReview.ReviewContent = review.ReviewContent;
                    previousReview.food_Id = review.food_Id;
                    previousReview.customer_Id = review.customer_Id;
                    //_context.Reviews.Add(previousReview);
                    _context.SaveChanges();
                }
                return "Review is Updated Successfully";
            }          
        }
    }
}
