using BLL;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using PruebaApi.Configuration;
using PruebaApi.Services;
using PruebaApi.Models;
using AutoMapper;

namespace PruebaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;
        private readonly ServiceJwt _jwtService;

        public LoginController(PruebaContext context, IOptions<AppSetting> appSettings, IMapper mapper)
        {
            _jwtService = new ServiceJwt(appSettings, mapper);
            _service = new LoginService(context);
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<IActionResult> Login(UsuarioInputModels model)
        {
            var user = await _service.Login(model.Correo, model.Password);
            if (user.Error)
            {
                return Unauthorized(user.Mensaje);
            }
            var response = _jwtService.GenerarToken(user.Objeto!);
            return Ok(response);
        }
    }
}
