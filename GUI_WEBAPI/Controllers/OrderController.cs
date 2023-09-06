using DAL.DatabaseContext;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUI_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly FanSalesContext _context;
        public OrderController(FanSalesContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsOrder = _context.Orders.ToList();
                return Ok(dsOrder);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var idOrder = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (idOrder != null)
            {
                return Ok(idOrder);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(Order ord)
        {
            try
            {
                var createOrder = new Order
                {
                    CustomerName = ord.CustomerName,
                    Address = ord.Address,
                    PhoneNumber = ord.PhoneNumber,
                    TotalAmount = ord.TotalAmount,
                    Status = ord.Status,
                    CreateAt = ord.CreateAt,
                    UpdateAt = ord.UpdateAt,
                    IsDelete = ord.IsDelete
                };
                _context.Add(createOrder);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, createOrder);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderById(Guid id, Order ord)
        {
            var idOrder = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (idOrder != null)
            {
                idOrder.CustomerName = ord.CustomerName;
                idOrder.Address = ord.Address;
                idOrder.PhoneNumber = ord.PhoneNumber;
                idOrder.TotalAmount = ord.TotalAmount;
                idOrder.Status = ord.Status;
                idOrder.CreateAt = ord.CreateAt;
                idOrder.UpdateAt = ord.UpdateAt;
                idOrder.IsDelete = ord.IsDelete;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(Guid id)
        {
            var idOrder = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (idOrder != null)
            {
                _context.Remove(idOrder);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
