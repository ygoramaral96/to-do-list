using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _connString;

        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("TodoApp");
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = "SELECT * FROM todo";

            DataTable table = new DataTable();
            
            NpgsqlDataReader dataReader;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    dataReader = command.ExecuteReader();
                    table.Load(dataReader);

                    dataReader.Close();
                    connection.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
