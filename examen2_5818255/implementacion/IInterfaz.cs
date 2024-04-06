using examen2_5818255.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static examen2_5818255.implementacion.implementacion;

namespace examen2_5818255.implementacion
{
    public interface IInterfaz
    {
        
        public Task<List<dtoReporte>> ListarTodos();
        public Task<List<dtoReporte2>> ListarTodos2();
        public Task<bool> Eliminar(int id);
        public Task<List<ProductosDto>> pregunta6(fechaProductoDto date);
    }
}
