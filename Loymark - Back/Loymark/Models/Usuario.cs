using System;
using System.Collections.Generic;

#nullable disable

namespace Loymark.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Actividades = new HashSet<Actividade>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal? Telefono { get; set; }
        public string PaisReferencia { get; set; }
        public bool RecibirInfo { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<Actividade> Actividades { get; set; }
    }
}
