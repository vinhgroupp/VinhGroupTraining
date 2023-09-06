using DAL.DatabaseContext;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GUI_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly FanSalesContext _context;
        public CategoryController(FanSalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsCate = _context.Categorys.ToList();
                return Ok(dsCate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var idCate = _context.Orders.SingleOrDefault(x => x.Id == id);
            if (idCate != null)
            {
                return Ok(idCate);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Authorize]
        public IActionResult CreateNew(Category cate)
        {
            try
            {
                var createCate = new Category
                {
                    Name = cate.Name,
                    CreateAt = cate.CreateAt,
                    UpdateAt = cate.UpdateAt,
                    IsDelete = cate.IsDelete
                };
                _context.Add(createCate);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, createCate);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCateById(Guid id, Category cate)
        {
            var idCate = _context.Categorys.SingleOrDefault(x => x.Id == id);
            if (idCate != null)
            {
                idCate.Name = cate.Name;
                idCate.CreateAt = cate.CreateAt;
                idCate.UpdateAt = cate.UpdateAt;
                idCate.IsDelete = cate.IsDelete;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCateById(Guid id)
        {
            var idCate = _context.Categorys.SingleOrDefault(x => x.Id == id);
            if (idCate != null)
            {
                _context.Remove(idCate);
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
