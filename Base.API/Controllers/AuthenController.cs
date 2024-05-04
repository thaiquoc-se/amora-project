using AutoMapper;
using Base.API.JWT;
using Base.Services.IService;
using Base.Services.ViewModel.RequestVM;
using Base.Services.ViewModel.ResponseVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base.API.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTService _jWTService;
        private readonly IMapper _mapper;
        public AuthenController(IUserService userService, IJWTService jWTService, IMapper mapper)
        {
            _userService = userService;
            _jWTService = jWTService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var check = await _userService.Login(login.Email!, login.Password!);
                if (check != null)
                {
                    var token = _jWTService.CreateToken(_mapper.Map<UserResponse>(check));
                    return Ok(new
                    {
                        message = "Login Successfully",
                        status = 200,
                        token = token,
                        data = _mapper.Map<UserResponse>(check)
                    });
                }
                return BadRequest(new
                {
                    message = "Incorect email or password",
                    status = 400
                });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
