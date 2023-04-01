using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loymark.Models;
using Loymark.Interfaces;
using AutoMapper;
using Loymark.DTO;

namespace Loymark.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _context;
        private readonly IMapper _mapper;


        public UsuariosController(IUsuariosService context)
        {
            _context = context;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.GetAll();

            if (usuarios.Count == 0 || usuarios == null)
            {
                var response = new MessageResponseDTO();
                response.status = 404;
                response.msj = "No se encontraron usuarios.";
                return NotFound(response);
            }

            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _context.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, UsuarioDTO usuario)
        {
            var response = await _context.UpdateUser(id, usuario);

            if (response.status == 404)
            {
                return NotFound(response);
            }

            if (response.status == 500 || response.status == 410)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(UsuarioDTO usuario)
        {

            var response = await _context.NewUser(usuario);

            if (response.status == 404)
            {
                return NotFound(response);
            }

            if (response.status == 500 || response.status == 410)
            {
                return BadRequest(response);
            }

            return Ok(response);

        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.DeleteUser(id);

            if(usuario.status == 404)
            {
                return NotFound(usuario);
            }

            if (usuario.status == 500 || usuario.status == 410)
            {
                return BadRequest(usuario);
            }

            return Ok(usuario);
        }

    }
}
