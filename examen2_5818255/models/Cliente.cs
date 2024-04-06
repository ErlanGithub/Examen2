using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2_5818255.models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
    }
}
