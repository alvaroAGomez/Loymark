using System;

namespace Loymark.DTO
{
    public class UsuarioDTO
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal? Telefono { get; set; }
        public string PaisReferencia { get; set; }
        public bool RecibirInfo { get; set; }
    }
}
