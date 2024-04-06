using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2_5818255.models
{
    public class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey("IdPedido")]
        public virtual Pedido Pedido { get; set; }

        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }

        public int cantidad { get; set; }
        public float precio { get; set; }
        public float subtotal { get; set; }
    }
}
