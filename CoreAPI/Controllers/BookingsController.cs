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
using CoreAPI.ViewModels;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //    // GET: api/Bookings
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<Booking>>> GetBooking()
        //    {
        //        return await _context.Booking.ToListAsync();
        //    }

        //    // GET: api/Bookings/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Booking>> GetBooking(int id)
        //    {
        //        var booking = await _context.Booking.FindAsync(id);

        //        if (booking == null)
        //        {
        //            return NotFound();
        //        }

        //        return booking;
        //    }

        //    // PUT: api/Bookings/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutBooking(int id, Booking booking)
        //    {
        //        if (id != booking.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(booking).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BookingExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/Bookings
        //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
        //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //    [HttpPost]
        //    public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        //    {
        //        _context.Booking.Add(booking);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetBooking", new { id = booking.Id }, booking);
        //    }

        //    // DELETE: api/Bookings/5
        //    [HttpDelete("{id}")]
        //    public async Task<ActionResult<Booking>> DeleteBooking(int id)
        //    {
        //        var booking = await _context.Booking.FindAsync(id);
        //        if (booking == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Booking.Remove(booking);
        //        await _context.SaveChangesAsync();

        //        return booking;
        //    }

        //    private bool BookingExists(int id)
        //    {
        //        return _context.Booking.Any(e => e.Id == id);
        //    }
        //}



        // retrieving All Types of Tables in Restaurant


        [HttpGet]
        [Route("BookingSearchOptions")]
        public List<int> BookingSearchOptions()
        {
            var typeList = (from t in _context.Tables
                                    group t by t.NOofPersons into nGroup
                                    where nGroup.Count() >= 1
                                    select nGroup.Key).ToList();
             return typeList;
        }

       
        ////Tryparse Method to compare dates
        //[HttpGet]
        //[Route("checkAvailability")]
        //public ActionResult<Table> checkAvailability(string Reserved, int chIN, int NOofGuests, string id)
        //{
        //    var res = new DateTime();
        //    DateTime.TryParse(Reserved, out res);
        //    List<Table> AllTables = _context.Tables.ToList();
        //    List<Booking> busyList = _context.Bookings.Where(m => (m.ReservedDate == res && m.CheckInTime == chIN)).ToList();
        //    List<Table> AvalilableTables = new List<Table>();
        //    foreach (var item in AllTables)
        //    {
        //        foreach (var all in busyList)
        //        {
        //            if (item.Id != all.table_Id && item.NOofPersons == NOofGuests)
        //            {
        //                AvalilableTables.Add(item);
        //            }
        //        }
        //    }
        //    Table ChoosenTable = new Table();
        //    ChoosenTable = AvalilableTables.FirstOrDefault();
        //    reserveTable(ChoosenTable, id, Reserved);
        //    return ChoosenTable;
        //}






        //compare Method to compare Dates
        //[HttpPost]
        //[Route("checkAvailability")]
        //public ActionResult<Table> checkAvailability(DateTime Reserved, int chIN, int NOofGuests, int id)
        //{
        //    List<Table> AllTables = _context.Tables.Where(t=>t.NOofPersons == NOofGuests).ToList();
        //    List<Booking> ReservedList = _context.Bookings.Where(m=> m.CheckInTime == chIN && m.table.NOofPersons == NOofGuests).ToList();
        //    //List<Booking> busyList = new List<Booking>();
        //    //foreach (var item in ReservedList)
        //    //{
        //    //    var res = DateTime.Compare(Reserved, item.ReservedDate.Value);
        //    //    if (res == 0 && item.CheckInTime == chIN )
        //    //    {
        //    //        busyList.Add(item);
        //    //    }
        //    //}

        //    List<Table> AvalilableTables = new List<Table>();
        //    foreach (var item in AllTables)
        //    {
        //        foreach (var all in ReservedList)
        //        {
        //            if (item.Id != all.table_Id)
        //            {
        //                AvalilableTables.Add(item);
        //            }
        //        }
        //    }
        //    Table ChoosenTable = new Table();
        //    ChoosenTable = AvalilableTables.FirstOrDefault();
        //    reserveTable(ChoosenTable, id, Reserved , chIN);
        //    return ChoosenTable;
        //}


        [HttpPost]
        [Route("getAvailableTable")]
        public ActionResult<Table> getAvailableTable(BookingViewModel bookingViewModel)
        {
            List<Table> AllTables = _context.Tables.Where(t => t.NOofPersons == bookingViewModel.NOofGuests).ToList();
            List<Booking> ReservedList = _context.Bookings.Where(m => m.CheckInTime == bookingViewModel.CheckInTime && m.table.NOofPersons == bookingViewModel.NOofGuests && m.ReservedDate == bookingViewModel.ReservedDate).ToList();
            List<Table> AvailableTables = new List<Table>();
            if (ReservedList.Count == 0)
            {
                AvailableTables = AllTables;
            }
            else
            {
                foreach (var item in AllTables)
                {
                    foreach (var all in ReservedList)
                    {
                        if (item.Id != all.table_Id)
                        {
                            AvailableTables.Add(item);
                        }
                    }
                }
            }
            if(AvailableTables.Count == 0)
            {
                return Ok("There is no available tables in this date");
            }
            Table ChoosenTable = new Table();
            ChoosenTable = AvailableTables.FirstOrDefault();
            return Ok(ChoosenTable);
        }


        // Reserve Only table
        [HttpPost]
        [Route("reserveTable")]
        public ActionResult<TableReceiptViewModel> reserveTable(BookingViewModel bookingViewModel)
        {
            List<Table> AllTables = _context.Tables.Where(t => t.NOofPersons == bookingViewModel.NOofGuests).ToList();
            List<Booking> ReservedList = _context.Bookings.Where(m => m.CheckInTime == bookingViewModel.CheckInTime && m.table.NOofPersons == bookingViewModel.NOofGuests && m.ReservedDate == bookingViewModel.ReservedDate).ToList();
            List<Table> AvailableTables = new List<Table>();
            if(ReservedList.Count == 0)
            {
                AvailableTables = AllTables;
            }
            else
            {
                foreach (var item in AllTables)
                {      
                    foreach (var all in ReservedList)
                    {
                        if (item.Id != all.table_Id)
                        {
                            AvailableTables.Add(item);
                        }
                    }                            
                }
            }
            Table ChoosenTable = new Table();
            ChoosenTable = AvailableTables.FirstOrDefault();
            Booking tableBooking = new Booking()
            {
                ReservationDate = DateTime.UtcNow,
                ReservedDate = bookingViewModel.ReservedDate,
                customer_Id = bookingViewModel.customer_Id,
                table_Id = ChoosenTable.Id,
                CheckInTime = bookingViewModel.CheckInTime,
                CheckOutTime = bookingViewModel.CheckInTime + 1
            };
            try
            {
                _context.Add(tableBooking);
                _context.SaveChanges();
                TableReceiptViewModel receipt = new TableReceiptViewModel()
                {
                    customerName =_context.Users.Where(s=>s.Id == bookingViewModel.customer_Id).Select(s=>s.UserName).FirstOrDefault(), 
                    CheckInTime = bookingViewModel.CheckInTime , 
                    CheckOutTime =bookingViewModel.CheckInTime +1, 
                    ReservedDate =bookingViewModel.ReservedDate.Value.ToString("dd/MM/yyyy") , 
                    NOofPersons = ChoosenTable.NOofPersons , 
                    tableNO = ChoosenTable.NO 
                };
                return Ok(receipt);
            }
            catch(Exception ex )
            {
                throw ex; 
            }
        }



        //[HttpPost]
        //[Route("bookTableWithOrder")]
        //public ActionResult<Food_Order> bookTableWithOrder(BookingOrderViewModel model)
        //{
        //    Booking booking = new Booking()
        //    {
        //        ReservationDate = DateTime.UtcNow,
        //        ReservedDate = model.booking.ReservedDate,
        //        customer_Id = model.booking.customer_Id,
        //        table_Id = model.booking.table_Id,
        //        CheckInTime = model.booking.CheckInTime,
        //        CheckOutTime = model.booking.CheckInTime + 1
        //    };
        //    _context.Add(booking);
        //    _context.SaveChanges();
        //    foreach (var item in model.food_ids)
        //    {
        //        Order order = new Order()
        //        {
        //            Date = DateTime.UtcNow,
        //        };
        //        _context.Add(order);
        //        _context.SaveChanges();
        //        Food_Order food_Order = new Food_Order()
        //        {
        //            //Quantity,
        //            OrderPrice = _context.Foods.Where(m => m.Id == item).Select(m => m.Price).FirstOrDefault(),
        //            food_Id = item,
        //            order_Id = order.Id,
        //            Food_OrderId = booking.Id
        //        };

        //    }
        //    return Ok();
        //}


        [HttpPost]
        [Route("bookTableWithOrder")]
        public ActionResult<ReceiptViewModel> bookTableWithOrder(BookingOrderViewModel model)
        {
            Booking booking = new Booking()
            {
                ReservationDate = DateTime.Now,
                ReservedDate = model.booking.ReservedDate,
                customer_Id = model.booking.customer_Id,
                table_Id = model.booking.table_Id,
                CheckInTime = model.booking.CheckInTime,
                CheckOutTime = model.booking.CheckInTime + 1 , 
                TotalPrice = 0 
            };
            _context.Add(booking);
            _context.SaveChanges();
            foreach (var item in model.food_Orders)
            {
                Order order = new Order()
                {
                    Date = DateTime.Now,
                };
                _context.Add(order);
                _context.SaveChanges();
                Food_Order food_Order = new Food_Order()
                {
                    Quantity = item.Quantity ,
                    OrderPrice = _context.Foods.Where(m => m.Id == item.food_Id).Select(m => m.Price).FirstOrDefault(),
                    food_Id = item.food_Id,
                    foodName = _context.Foods.Where(m => m.Id == item.food_Id).Select(m => m.Name).FirstOrDefault(),
                    order_Id = order.Id,
                    booking_Id = booking.Id , 
                    TotalOrderPrice = item.Quantity * _context.Foods.Where(m => m.Id == item.food_Id).Select(m => m.Price).FirstOrDefault(),
                };
                _context.Add(food_Order);
                _context.SaveChanges();
                Food ExistedFood = _context.Foods.Where(f => f.Id == item.food_Id).FirstOrDefault();
                ExistedFood.Stock = ExistedFood.Stock - item.Quantity.Value;
                _context.SaveChanges();
                booking.TotalPrice += food_Order.TotalOrderPrice.Value;
                _context.SaveChanges();
            }
            ReceiptViewModel receipt = new ReceiptViewModel();
            receipt.customerName = _context.Customers.Where(c => c.UserId == booking.customer_Id).Select(c => c.Name).FirstOrDefault();
            receipt.tableNO = _context.Tables.Where(c => c.Id == booking.table_Id).Select(c => c.NO).FirstOrDefault();
            receipt.NOofPersons = _context.Tables.Where(c => c.Id == booking.table_Id).Select(c => c.NOofPersons).FirstOrDefault();
            receipt.ReservedDate = booking.ReservedDate.Value.ToString("dd/MM/yyyy");
            receipt.CheckInTime = booking.CheckInTime;
            receipt.CheckOutTime = booking.CheckOutTime;
            List<Food_Order> customerFoodOrders = _context.Food_Orders.Where(f => f.booking == booking).ToList();
            receipt.foodOrders = customerFoodOrders;
            receipt.TotalBookingPrice = booking.TotalPrice;
            return Ok(receipt);
        }



        ////[HttpPost]
        //public ActionResult<Booking> reserveTable(Table ChoosenTable, int id, DateTime Reserved , int chIN)
        //{
        //    Booking tableBooking = new Booking()
        //    {
        //        ReservationDate = DateTime.UtcNow,
        //        ReservedDate = Reserved,
        //        customer_Id = id,
        //        table_Id = ChoosenTable.Id,
        //        CheckInTime = chIN , 
        //        CheckOutTime = chIN+1
        //    };
        //    _context.Add(tableBooking);
        //    _context.SaveChanges();
        //    return tableBooking;
        //}


        //[Route("checkAvailability")]
        //[HttpGet]
        //public ActionResult<Table> checkAvailability(int chIN)
        //{
        //    List<Table> AllTables = _context.Tables.ToList();
        //    List<Booking> busyList = _context.Bookings.Where(m => m.CheckInTime == chIN).ToList();
        //    List<Table> AvalilableTables = new List<Table>();
        //    foreach (var item in AllTables)
        //    {
        //        foreach (var all in busyList)
        //        {
        //            if (item.Id != all.table_Id)
        //            {
        //                AvalilableTables.Add(item);
        //            }
        //        }
        //    }
        //    Table ChoosenTable = new Table();
        //    ChoosenTable = AvalilableTables.FirstOrDefault<Table>();
        //    return ChoosenTable;
        //}
    }
}
