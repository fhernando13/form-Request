using apiRequestForm.Entities;
using apiRequestForm.Entities.DTO;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;

namespace apiRequestForm.Controllers
{    
    [ApiController]
    [Route("api/mun")]
    public class MunicipalityController : ControllerBase
    {
        private readonly string defaultConnection;

        public MunicipalityController(IConfiguration config)
        {
            defaultConnection = config.GetConnectionString("DefaultConnection");
        }

        //get all states
        [HttpGet("getall")]
        public IActionResult List()
        {
            List<MunicipalityDTO> list = new List<MunicipalityDTO>();
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_GET_MUN", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new MunicipalityDTO()
                            {
                                IdMunicipality = Convert.ToInt32(rd["IdMunicipality"]),
                                NameMunicipality = rd["NameMunicipality"].ToString(),
                                StateId = Convert.ToInt32(rd["StateId"]),
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message, response = list });
            }
        }
        //Add mun
        [HttpPost("addmun")]
        public IActionResult Save([FromBody] MunicipalityDTO municipality)
        {
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_ADD_MUN", conexion);
                    cmd.Parameters.AddWithValue("NameMunicipality", municipality.NameMunicipality);
                    cmd.Parameters.AddWithValue("StateId", municipality.StateId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message, response = municipality });
            }
        }
    }
}
