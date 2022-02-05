using HomeDepot.Controllers.v1;
using HomeDepot.DomainLayer.BusinessObject;
using HomeDepot.DomainLayer.DTO;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace HomeDepot.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsApiV2Controller : ApiController
    {
        private readonly BOProducts manager;

        public ProductsApiV2Controller()
        {
            manager = new BOProducts(Constants.ConnStringDev);
        }
        // GET: api/ProductApi
        /// <summary>
        /// Obtienes el listado de todos los productos.
        /// </summary>
        /// <remarks>
        /// Recuerdas que pueden ser productos activos e inactivos.
        /// </remarks>
        /// <response code="401">Unauthorized. No cuentas con permisos.</response>
        /// <response code="200">OK. Devuelve el listado solicitado.</response>       
        public HttpResponseMessage Get()
        {
            var result = new
            {
                message = "Productos encontrados.",
                result = manager.GetAll()
            };
            return new HttpResponseMessage(HttpStatusCode.Created)
            {                
                Content = new StringContent(JsonConvert.SerializeObject(result))
            };
        }
    }
}
public class BaseReponse : IHttpActionResult
{
    private readonly string message;
    private readonly string result;
    private readonly HttpRequestMessage request;

    public BaseReponse(string message, HttpRequestMessage request)
    {
        this.message = message;
        this.request = request;
    }

    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage
        {
            StatusCode = (HttpStatusCode)423,
            RequestMessage = this.request,
            Content = new StringContent(this.message)
        };

        return Task.FromResult(response);
    }
}