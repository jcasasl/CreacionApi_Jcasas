using Capa_Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Examen_JuniorCasas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly IConfiguration _configuration;
        public ProductoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult ListaProducto()
        {

            DataTable table = new DataTable();

            Dato_Producto data = new Dato_Producto();

            //Recupero la Conexion del appseting
            string sqlDataSource = _configuration.GetConnectionString("con").ToString();
            //obtengo la informacion del metodo listar Producto de la capa de datos
            table = data.ListaProducto(sqlDataSource);



            return new JsonResult(table);
        }
    }
}
