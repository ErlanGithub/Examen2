using examen2_5818255.models;
using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen2_5818255.implementacion
{
    public class implementacion: IInterfaz
    {
        private readonly Contexto contexto;
        public implementacion (Contexto contexto)
        {
            this.contexto = contexto;
        }
        //2.- Listar el siguiente reporte nombrecliente,fecha pedido, nombre del producto y subtotal
        public class dtoReporte
        {
            public string nombreCli { get; set; }
            public DateTime fecha { get; set; }
            public string nombrePro { get; set; }
            public float subtotal { get; set; }
        }
        
        public async Task<List<dtoReporte>> ListarTodos()
        {
            var resultado = await contexto.Detalles.Select(x => new dtoReporte
            {
                nombreCli = x.Pedido.Cliente.Nombre,
                fecha = x.Pedido.fecha,
                subtotal = x.subtotal,
                nombrePro = x.Producto.Nombre
            }).ToListAsync();
            return resultado;
        }
        //3.- Realizar el siguiente reporteidentificar los 3 productos mas pedidos(solicitados)
        public class dtoReporte2
        {
            
            public string nombrePro { get; set; }
            public int idProducto { get; set; }
            public int cantidad { get; set; }

        }
        public async Task<List<dtoReporte2>> ListarTodos2()
        {
            var resultado = await contexto.Detalles.OrderByDescending(v => v.cantidad).Take(3).Select(x => new dtoReporte2
            {
                idProducto = x.IdProducto,
                nombrePro = x.Producto.Nombre,
                cantidad = x.cantidad

            }).ToListAsync();
            return resultado;
        }
        //5.- Realizar un endpoint para reALIZAR UN ELIMINADO EN CASCADA DE LA TABLA CLIENTE
        public async Task<bool> Eliminar(int id)
        {
            bool sw = false;
            Cliente Eliminar = await contexto.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);
            if (Eliminar != null)
            {
                contexto.Remove(Eliminar);
                await contexto.SaveChangesAsync();
                return sw = true;
            }
            else { return sw; }
        }
        //6.- Realizar un endpoint que determine cuales son los productos mas vendidos segun un rango de fechas como parametros
        public class ProductosDto
        {
            public int idProducto { get; set; }
            public string nombreProducto { get; set; }
            public int cantidad { get; set; }
        }
        public class fechaProductoDto
        {
            public DateTime fechaInicio { get; set; }
            public DateTime fechaFinal { get; set; }
        }
  
        public async Task<List<ProductosDto>> pregunta6(fechaProductoDto date)
        {
            var resultado = await contexto.Detalles.Where(f => f.Pedido.fecha >= date.fechaInicio && f.Pedido.fecha <= date.fechaFinal)
                .OrderBy(p => p.cantidad).Take(2)
                .Select(prod => new ProductosDto
                {
                    idProducto = prod.IdProducto,
                    nombreProducto = prod.Producto.Nombre,
                    cantidad = prod.cantidad
                }).ToListAsync();
            return resultado;
        }
    }
}
