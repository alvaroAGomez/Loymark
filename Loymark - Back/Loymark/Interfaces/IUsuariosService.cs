using Loymark.DTO;
using Loymark.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Loymark.Interfaces
{
    public interface IUsuariosService 
    {
        Task<List<UsuarioDTO>> GetAll();
        Task<UsuarioDTO> GetById(int id);

        Task<MessageResponseDTO> NewUser(UsuarioDTO user);
        Task<MessageResponseDTO> UpdateUser(int id, UsuarioDTO user);
        Task<MessageResponseDTO> DeleteUser(int id);


    }
}
