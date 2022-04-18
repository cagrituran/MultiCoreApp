using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _cusService;
        private IMapper _mapper;

        public CustomerController(ICustomerService cusService, IMapper mapper)
        {
            _cusService = cusService;
            _mapper = mapper;   
        }
        [HttpGet]//Select işlemleri için api kullanılan keywordu
        public async Task<IActionResult> GetAll()
        {
            var cus = await _cusService.GetAllAsync();
            //return Ok(cat);
            return Ok(_mapper.Map<IEnumerable<CustomerDto>>(cus));
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cus = await _cusService.GetByIdAsync(id);
            return Ok(_mapper.Map<CustomerDto>(cus));
        }
        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto cusDto)
        {
            var newCus = await _cusService.AddAsync(_mapper.Map<Customer>(cusDto));
            return Created(string.Empty, _mapper.Map<CustomerDto>(newCus));
        }
        [HttpPut]
        public IActionResult Update(CustomerDto cusDto)
        {
            var cat = _cusService.Update(_mapper.Map<Customer>(cusDto));
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public IActionResult Remove(Guid id)
        {
            var cus = _cusService.GetByIdAsync(id).Result; // Result senkron yapılarda asenkron metodu calıstırdıgı için hatayı engellemek için
            _cusService.Remove(cus);
            return NoContent();
        }
        [HttpDelete("{name}")]
        public IActionResult RemoveByName(string name)
        {
            var cus = _cusService.Where(s => s.Name == name).Result;
            _cusService.RemoveRange(cus);
            return NoContent();
        }
    }
}
