using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Data;
using CoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpGet]
        [Route("charge")]
        public string charge ([FromBody] string stripeEmail , string stripeToken)
        {
            var Cutomers = new CustomerService();
            var charges = new ChargeService();
            var customer = Cutomers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail , 
                Source = stripeToken
            });
            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500 , 
                Description  = "",
                Currency = "USD" , 
                Customer = customer.Id , 
                ReceiptEmail = stripeEmail
            });
            if(charge.Status == "succeeded")
            {
                string TransactionId = charge.BalanceTransactionId;
            }
            return "OK";
        }
    }
}
