using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.API.DTOs;
using MultiCoreApp.Core.Responses;
using MultiCoreApp.Core.IntService;
using MultiCoreApp.Core.Models;
using System.Security.Claims;

namespace MultiCoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService,IMapper mapper)
        {
           _userService = userService;
          _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUser()
        {
            IEnumerable<Claim> claims = User.Claims;
            string userId = claims.Where(s => s.Type==ClaimTypes.NameIdentifier).First().Value;
            var useResponse = _userService.UserFindById(int.Parse(userId));
            var user = _mapper.Map<BaseResponse<User>>(useResponse);
            if (user.Success)
            {
                return Ok(user.Extra);
            }
            else
            {
                return BadRequest(user.ErrorMessage);
            }
        }
        [HttpPost]
        public IActionResult AddUser(UserDto userDto)
        {
            User user = _mapper.Map<UserDto,User>(userDto);
            var userResponse = _userService.AddAsync(user);
            var ur = _mapper.Map<BaseResponse<User>>(userResponse);
            if (ur.Success)
            {
                return Ok(ur.Extra);

            }
            else
            {//dfdffdsadasdadsdas
                return BadRequest(ur.ErrorMessage);
            }
        }

    }
}
