using DAL.DatabaseContext;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace GUI_WEBAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : Controller
    {
        private readonly FanSalesContext _context;
        public BrandController(FanSalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsBrand = _context.Brands.ToList();
                return Ok(dsBrand);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var idBrand = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (idBrand != null)
            {
                return Ok(idBrand);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(Brand br)
        {
            try
            {
                var createBr = new Brand
                {
                    Name = br.Name,
                    CreateAt = br.CreateAt,
                    UpdateAt = br.UpdateAt,
                    IsDelete = br.IsDelete
                };
                _context.Add(createBr);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, createBr);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrandById(Guid id, Brand br)
        {
            var idBr = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (idBr != null)
            {
                idBr.Name = br.Name;
                idBr.CreateAt = br.CreateAt;
                idBr.UpdateAt = br.UpdateAt;
                idBr.IsDelete = br.IsDelete;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrandById(Guid id)
        {
            var idBr = _context.Brands.SingleOrDefault(x => x.Id == id);
            if (idBr != null)
            {
                _context.Remove(idBr);
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
