using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loymark.Models;
using Loymark.DTO;
using AutoMapper;
using Loymark.Interfaces;

namespace Loymark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly IActividadesServices _context;


        public ActividadesController(IActividadesServices context)
        {
            _context = context;

        }

        // GET: api/Actividades
        [HttpGet]
        public async Task<IActionResult> GetActividades()
        {
            var actividades = await _context.GetAll();
            
            if(actividades.Count == 0 || actividades == null)
            {
                var response = new MessageResponseDTO();
                response.status = 404;
                response.msj = "No se encontraron registros.";
                return NotFound(response);
            }

           


            return Ok(actividades);
        }
    }
}
