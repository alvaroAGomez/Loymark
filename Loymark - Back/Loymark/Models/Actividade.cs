using System;
using System.Collections.Generic;

#nullable disable

namespace Loymark.Models
{
    public partial class Actividade
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int IdUsuario { get; set; }
        public string Actividad { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
