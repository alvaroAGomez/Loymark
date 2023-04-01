using Loymark.DTO;
using Loymark.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loymark.Interfaces
{
    public interface IActividadesServices 

    {
        Task<List<ActividadDTO>> GetAll();
        Task<bool> NewActividad(Actividade actividad);
    }
}
