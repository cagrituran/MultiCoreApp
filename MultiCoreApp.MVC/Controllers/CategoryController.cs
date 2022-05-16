using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, CategoryApiService categoryApiService, IMapper mapper)
        {
            _categoryService = categoryService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;   
        }
        public async Task<IActionResult> Index()
        {
            //var categories = await _categoryService.GetAllAsync();
            //return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
            IEnumerable<CategoryDto> cat = await _categoryApiService.GetAllAsync();
            return View(cat);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var catDto = await _categoryApiService.GetByIdAsync(id);
            return View(catDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryApiService.AddAsync(categoryDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var cat = await _categoryApiService.GetByIdAsync(id);
            return View(cat);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto catDto)
        {
            await _categoryApiService.Update(catDto);
            return RedirectToAction("Index");
        }
    }
}
