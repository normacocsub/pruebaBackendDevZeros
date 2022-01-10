using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaApi.Models;
using PruebaApi.Configuration;

namespace pruebaApi.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _service;
        private readonly LoginService _serviceLogin;
        private readonly IMapper _mapper;
        public LibraryController(PruebaContext context, IMapper mapper)
        {
            _service = new LibraryService(context);
            _serviceLogin = new LoginService(context);
            _mapper = mapper;
        }

        [AutorizeRoles(Rol = "Administrado", Permiso = "GuardarLibro")]
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<IActionResult> Guardar(LibraryInputModels libraryInput)
        {
            var result = await _service.Guardar(_mapper.Map<Library>(libraryInput));
            return ResponseHttp(result);
        }

        [HttpGet]
        public async Task<IActionResult> Consultar()
        {
            var result = await _service.GetLibraries();
            return ResponseHttp(result);
        }

        [Authorize(Roles = "Administrador")]
        [AutorizeRoles(Rol = "Administrador", Permiso = "BuscarLibro")]
        [HttpGet("{id}")]
        public async Task<IActionResult> SearchLibrary(int id)
        {
            var result = await _service.GetLibrary(id);
            return ResponseHttp(result);
        }

        [Authorize(Roles = "Administrador")]
        [AutorizeRoles(Rol = "Administrador", Permiso = "ActualizarLibro")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibrary(LibraryInputModels libraryInput, int id)
        {
            var result = await _service.UpdateLibrary(_mapper.Map<Library>(libraryInput), id);
            return ResponseHttp(result);
        }
        [Authorize(Roles = "Administrador")]
        [AutorizeRoles(Rol = "Administrador", Permiso = "EliminarLibro")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            var result = await _service.DeleteLibrary(id);
            return ResponseHttp(result);
        }

        private ObjectResult ResponseHttp(ResponseClass<Library> result)
        {
            if (result.Error)
            {
                return BadRequest(result.Mensaje);
            }
            else if(result.Objects != null)
            {
                return Ok(_mapper.Map<List<LibraryOutputModels>>(result.Objects));
            }
            return Ok(_mapper.Map<LibraryOutputModels>(result.Objeto));
        }
    }
}
