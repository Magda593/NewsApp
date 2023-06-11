using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsApi.Models;

namespace NewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        static List<Category> categories = new List<Category> { new Category { Id = Guid.NewGuid(), CategoryId = "1", Name = "Course"},
            new Category { Id = Guid.NewGuid(), CategoryId = "2", Name = "General"},
            new Category { Id = Guid.NewGuid(), CategoryId = "3", Name = "Laboratory" }
        };
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }

        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return Ok(existingCategory);
        }

        /// <summary>
        /// Delete Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            categories.Remove(existingCategory);
            return Ok();
        }

        /// <summary>
        /// Post Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult PostCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return Ok(existingCategory);
        }
    }
}
