using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _catService;
        public CategoryController(ICategoryService catService)
        {
            _catService = catService;

        }
        [HttpGet]//Select işlemleri için api kullanılan keywordu
        public async Task<IActionResult> GetAll()
        {
            var cat = await _catService.GetAllAsync();
            return Ok(cat);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cat = await _catService.GetByIdAsync(id);
            return Ok(cat);
        }
    }
}
