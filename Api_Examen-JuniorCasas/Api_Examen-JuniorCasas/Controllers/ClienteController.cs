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
    public class ClienteController : Controller
    {
        private readonly IConfiguration _configuration;
        public ClienteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        public JsonResult ListaCliente()
        {

            DataTable table = new DataTable();

            Dato_Cliente data = new Dato_Cliente();
            //Recupero la Conexion del appseting
            string sqlDataSource = _configuration.GetConnectionString("con").ToString();
            //obtengo la informacion del metodo listar cliente de la capa de datos
            table = data.ListaCliente(sqlDataSource);



            return new JsonResult(table);
        }

    }
}
