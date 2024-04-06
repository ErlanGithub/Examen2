using System.Net;
using examen2_5818255.implementacion;
using examen2_5818255.models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using static examen2_5818255.implementacion.implementacion;

namespace examen2_5818255.endpoint
{
    public class endpoints
    {
        private readonly ILogger _logger;
        private readonly IInterfaz interfaz;
        public endpoints(ILoggerFactory loggerFactory, IInterfaz interfaz)
        {
            _logger = loggerFactory.CreateLogger<endpoints>();
            this.interfaz = interfaz;
        }

       
        [Function("Pregunta2")]
        [OpenApiOperation("Listar", "pregunta1", Description = "")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<dtoReporte>),
            Description = "mostrara una lista ")]
        public async Task<HttpResponseData> ListarTodos([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var lista = interfaz.ListarTodos();
                respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(lista.Result);
                return respuesta;
            }
            catch (Exception)
            {
                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }
        [Function("Pregunta3")]
        [OpenApiOperation("Listar", "Pregunta2", Description = "")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<dtoReporte2>),
            Description = "mostrara una lista ")]
        public async Task<HttpResponseData> ListarTodos2([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var lista = interfaz.ListarTodos2();
                respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(lista.Result);
                return respuesta;
            }
            catch (Exception)
            {
                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }

        }

        [Function("pregunta5")]
        [OpenApiOperation("Listar", "Eliminar", Description = "Sirve para eliminar")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(void),
            Description = " eliminar")]
        [OpenApiParameter(name: "id", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "")]
        public async Task<HttpResponseData> Eliminar(
        [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "eliminar")] HttpRequestData req,
        FunctionContext context)
        {
            HttpResponseData respuesta;
            int id =Convert.ToInt32( req.Query["id"]);
            bool sw = await interfaz.Eliminar(id);

            if (sw)
            {
                respuesta = req.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
            }

            return respuesta;
        }

        [Function("pregunta6")]
        [OpenApiOperation("Listar", "pregunta6", Description = "")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json",
            bodyType: typeof(ProductosDto),
            Description = "")]
        [OpenApiParameter(name: "fecha", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "")]
        public async Task<HttpResponseData> Obtener(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "obtener")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            DateTime fecha = Convert.ToDateTime( req.Query["fecha"]);
            try
            {
               
                respuesta = req.CreateResponse(HttpStatusCode.OK);
                
                return respuesta;
            }
            catch (Exception)
            {
                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }

        }
    }
}
