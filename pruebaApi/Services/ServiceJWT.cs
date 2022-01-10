using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BLL;
using PruebaApi.Configuration;
using Microsoft.Extensions.Options;
using PruebaApi.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using AutoMapper;

namespace PruebaApi.Services
{
    public class ServiceJwt
    {
        private readonly AppSetting _appSetting;
        private readonly IMapper _mapper;
        public ServiceJwt(IOptions<AppSetting> appSetting, IMapper mapper)
        {
            _appSetting = appSetting.Value;
            _mapper = mapper;
        }

        public UsuarioViewModels GenerarToken(Usuario usuario)
        {
            if (usuario == null)
                return null;
            var usuarioViewModel = _mapper.Map<UsuarioViewModels>(usuario);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Email, usuario.Correo));
            claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuarioViewModel.Token = tokenHandler.WriteToken(token);

            return usuarioViewModel;
        }
    }
}
