using HomeDepot.DomainLayer.BusinessObject;
using HomeDepot.DomainLayer.DTO;
using HomeDepot.DomainLayer.RQ;
using Microsoft.Web.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace HomeDepot.Controllers.v1
{
    public class Constants
    {
        public static string ConnStringDev = "Server=LAPTOP-LA2FAGIE\\SQL2019;Database=CursoCotizaciones;Trusted_Connection=True;";
        public static string ConnStringProd = "Server=LAPTOP-LA2FAGIE\\SQL2019;Database=CursoCotizaciones;Trusted_Connection=True;";
    }

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    /// <summary>
    /// Administracion de productos.
    /// </summary>
    public class ProductsApiV1Controller : ApiController
    {
        private readonly BOProducts manager;

        public ProductsApiV1Controller()
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
        public XmlResult Get()
        {
            return new XmlResult(manager.GetAll());

        }

        // GET: api/ProductApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProductApi
        public HttpResponseMessage Post(RQProduct request)
        {
            var result = manager.Insert(request);
            if (result != null)
            {
                return new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(result))
                };
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        // PUT: api/ProductApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProductApi/5
        public void Delete(int id)
        {
        }
    }
}


public class XmlResult : ActionResult
{
    private object objectToSerialize;

    /// <summary>
    /// Initializes a new instance of the <see cref="XmlResult"/> class.
    /// </summary>
    /// <param name="objectToSerialize">The object to serialize to XML.</param>
    public XmlResult(object objectToSerialize)
    {
        this.objectToSerialize = objectToSerialize;
    }

    /// <summary>
    /// Gets the object to be serialized to XML.
    /// </summary>
    public object ObjectToSerialize
    {
        get { return this.objectToSerialize; }
    }

    /// <summary>
    /// Serialises the object that was passed into the constructor to XML and writes the corresponding XML to the result stream.
    /// </summary>
    /// <param name="context">The controller context for the current request.</param>
    public override void ExecuteResult(ControllerContext context)
    {
        if (this.objectToSerialize != null)
        {
            context.HttpContext.Response.Clear();
            var xs = new System.Xml.Serialization.XmlSerializer(this.objectToSerialize.GetType());
            context.HttpContext.Response.ContentType = "text/xml";
            xs.Serialize(context.HttpContext.Response.Output, this.objectToSerialize);
        }
    }
}