using Loymark.Interfaces;
using Loymark.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using Loymark.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Linq;

namespace Loymark.Servicios
{
    public class UsuariosService : IUsuariosService
    {

        private readonly LoymarkContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IActividadesServices _actividadesServices;
        public UsuariosService(LoymarkContext context, IMapper mapper, IActividadesServices actividadesServices)
        {
            _dbContext = context;
            _mapper = mapper;
            _actividadesServices = actividadesServices;
        }

        public async Task<MessageResponseDTO> DeleteUser(int id)
        {
            var userDelete = await _dbContext.Usuarios.Where(x => x.FechaBaja == null && x.Id == id).FirstOrDefaultAsync();
            if (userDelete == null)
            {
                var response = new MessageResponseDTO();
                response.status = 404;
                response.msj = "Usuario no encontrado.";
            }

            userDelete.FechaBaja = DateTime.Now;
            using (var dbTran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Usuarios.Attach(userDelete);

                    _dbContext.Entry(userDelete).State = EntityState.Modified;



                    _dbContext.SaveChanges();

                    _dbContext.Entry(userDelete).State = EntityState.Detached;

                    var registroActivadad = new Actividade();
                    registroActivadad.CreateDate = DateTime.Now;
                    registroActivadad.IdUsuario = id;
                    registroActivadad.Actividad = "Eliminacion de usuario";

                    var response = new MessageResponseDTO();
                    if (!await _actividadesServices.NewActividad(registroActivadad))
                    {
                       
                        response.status = 400;
                        response.msj = "Error al gravar la actividad";
                        dbTran.Rollback();
                        return response;
                    }


                    dbTran.Commit();
                   
                    response.status = 200;
                    response.msj = "Se elimino con exito el usuario.";

                    return response;
                }
                catch (Exception e)
                {

                    var response = new MessageResponseDTO();
                    response.status = 500;
                    response.msj = "Excepcion";
                    response.excepcion = e.Message;
                    dbTran.Rollback();
                    return response;
                }
            }

        }

        public async Task<List<UsuarioDTO>> GetAll()
        {
            var usuarios = await _dbContext.Usuarios.Where(x=>x.FechaBaja==null).ToListAsync();
            try
            {
                var result = _mapper.Map<List<Usuario>, List<UsuarioDTO>>(usuarios);
                return result;

            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        public async Task<UsuarioDTO> GetById(int id)
        {
            var usuario = await _dbContext.Usuarios.Where(x => x.FechaBaja == null && x.Id == id).FirstOrDefaultAsync() ;
            if(usuario == null) { return null; }

            var userDTO = _mapper.Map<Usuario, UsuarioDTO>(usuario);
            return userDTO; 

        }

        public async Task<MessageResponseDTO> NewUser(UsuarioDTO user)
        {
           var nuevoUsuario = _mapper.Map<UsuarioDTO, Usuario>(user);

            using (var dbTran = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    _dbContext.Add(nuevoUsuario);
                    _dbContext.SaveChanges();


                    _dbContext.Entry(nuevoUsuario).State = EntityState.Detached;

                    var registroActivadad = new Actividade();
                    registroActivadad.CreateDate = DateTime.Now;
                    registroActivadad.IdUsuario = nuevoUsuario.Id;
                    registroActivadad.Actividad = "Creación de Usuario";

                    var response = new MessageResponseDTO();
                    if (!await _actividadesServices.NewActividad(registroActivadad))
                    {

                        response.status = 400;
                        response.msj = "Error al gravar la actividad";
                        dbTran.Rollback();
                        return response;
                    }

                    dbTran.Commit();
                    
                    response.status = 200;
                    response.msj = "Se registro con exito el usuario.";

                    return response;
                }
                catch (Exception e)
                {

                    var response = new MessageResponseDTO();
                    response.status = 500;
                    response.msj = "Excepcion";
                    response.excepcion = e.Message;
                    dbTran.Rollback();
                    return response;

                }
            }       
        }

        public async Task<MessageResponseDTO> UpdateUser(int id, UsuarioDTO user)
        {
            var exist = await  _dbContext.Usuarios.Where(x => x.FechaBaja == null && x.Id == id).FirstOrDefaultAsync();
            if (exist == null)
            {
                var response = new MessageResponseDTO();
                response.status = 404;
                response.msj = "Usuario no encontrado";
                return response;
            }
            _dbContext.Entry(exist).State = EntityState.Detached;


            var usuarioUpdate = _mapper.Map<UsuarioDTO, Usuario>(user);

            using (var dbTran = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Entry(usuarioUpdate).Property("Id").IsModified = false;
                //    _dbContext.Usuarios.Attach(usuarioUpdate);

                    _dbContext.Entry(usuarioUpdate).State = EntityState.Modified;

                    

                    _dbContext.SaveChanges();

                    _dbContext.Entry(usuarioUpdate).State = EntityState.Detached;

                    var registroActivadad = new Actividade();
                    registroActivadad.CreateDate = DateTime.Now;
                    registroActivadad.IdUsuario = usuarioUpdate.Id;
                    registroActivadad.Actividad = "Actualizacion de Usuario";

                    var response = new MessageResponseDTO();
                    if (!await _actividadesServices.NewActividad(registroActivadad))
                    {

                        response.status = 400;
                        response.msj = "Error al gravar la actividad";
                        dbTran.Rollback();
                        return response;
                    }

                    dbTran.Commit();
                    response.status = 200;
                    response.msj = "Se actualizo con exito el usuario.";

                    return response;
                }
                catch (Exception e)
                {

                    var response = new MessageResponseDTO();
                    response.status = 500;
                    response.msj = "Excepcion";
                    response.excepcion = e.Message;
                    dbTran.Rollback();
                    return response;
                }
            }
        }
    }
}
