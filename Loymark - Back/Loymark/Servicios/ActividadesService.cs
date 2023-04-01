using Loymark.Interfaces;
using Loymark.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Loymark.DTO;

namespace Loymark.Servicios
{
    public class ActividadesService : IActividadesServices
    {
        private readonly LoymarkContext _dbContext;
        private readonly IMapper _mapper;
        public ActividadesService(LoymarkContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<List<ActividadDTO>> GetAll()
        {
            var actividades =await _dbContext.Actividades.Include(x=>x.IdUsuarioNavigation).ToListAsync();
            try
            {
                var result = _mapper.Map<List<Actividade>, List<ActividadDTO>>(actividades);
                return result;

            }
            catch (Exception e)
            {
                return null;
                throw;
            }

          

        }

        public async Task<bool> NewActividad(Actividade actividad)
        {
        
                try
                {

                    _dbContext.Add(actividad);
                    _dbContext.SaveChanges();


                    _dbContext.Entry(actividad).State = EntityState.Detached;



                    return true;
                }
                catch (Exception e)
                {
                    return false;

                }
            
        }
    }
}
