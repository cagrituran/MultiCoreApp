using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _proService;
        private readonly ProductApiService _proApiService;
        private readonly IMapper _iMapper;
        public ProductController(IProductService proService, ProductApiService proApiService, IMapper imapper)
        {
            _proApiService = proApiService;
            _proService = proService;
            _iMapper = imapper;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDto> pro = await _proApiService.GetAllAsync();
            return View(pro);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var proDto = await _proApiService.GetByIdAsync(id);
            return View(proDto);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductDto proDto)
        {
            await _proApiService.AddAsync(proDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var cat = await _proApiService.GetByIdAsync(id);
            return View(cat);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductDto proDto)
        {
            await _proApiService.Update(proDto);
            return RedirectToAction("Index");
        }
    }
}
