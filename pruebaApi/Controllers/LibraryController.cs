using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pruebaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryService _service;

        public LibraryController(PruebaContext context)
        {
            _service = new LibraryService(context);
        }

        [HttpPost]
        public async Task<IActionResult> Guardar()
        {
            var result = await _service.Guardar(new Library());
            if(result != null) { return Ok(result); }
            return BadRequest(result);
        }
    }
}
