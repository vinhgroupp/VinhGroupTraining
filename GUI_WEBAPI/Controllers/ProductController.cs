using DAL.DatabaseContext;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUI_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly FanSalesContext _context;
        public ProductController(FanSalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsProd = _context.Products.ToList();
                return Ok(dsProd);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var idProd = _context.Products.SingleOrDefault(x => x.Id == id);
            if (idProd != null)
            {
                return Ok(idProd);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(Product prod)
        {
            try
            {
                var createProd = new Product
                {
                    Name = prod.Name,
                    Price = prod.Price,
                    Description = prod.Description,
                    CreateAt = prod.CreateAt,
                    UpdateAt = prod.UpdateAt,
                    IsDelete = prod.IsDelete
                };
                _context.Add(createProd);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, createProd);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProdById(Guid id, Product prod)
        {
            var idprod = _context.Products.SingleOrDefault(x => x.Id == id);
            if (idprod != null)
            {
                idprod.Name = prod.Name;
                idprod.Price = prod.Price;
                idprod.Description = prod.Description;
                idprod.CreateAt = prod.CreateAt;
                idprod.UpdateAt = prod.UpdateAt;
                idprod.IsDelete = prod.IsDelete;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProdById(Guid id)
        {
            var idProd = _context.Products.SingleOrDefault(x => x.Id == id);
            if (idProd != null)
            {
                _context.Remove(idProd);
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
