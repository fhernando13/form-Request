using Microsoft.AspNetCore.Mvc;
using apiRequestForm.Entities;

using System.Data;
using System.Data.SqlClient;

namespace apiRequestForm.Controllers
{
    
    [Route("api/states")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly string defaultConnection;

        public StateController(IConfiguration config) 
        {
            defaultConnection = config.GetConnectionString("DefaultConnection");              
        }

        //get all states
        [HttpGet("getall")]
        public IActionResult List() 
        {
            List<State> list = new List<State>();
            try 
            {
                using (var conexion = new SqlConnection(defaultConnection)) 
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_GET_STATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader()) 
                    { 
                        while(rd.Read()) {
                            list.Add(new State()
                            {
                                IdState = Convert.ToInt32(rd["IdState"]),
                                NameState = rd["NameState"].ToString()
                            });
                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = list });
            }
            catch (Exception error) {
                return StatusCode(StatusCodes.Status500InternalServerError , new { message = error.Message, response = list });
            }
        }

        //get one state
        [HttpGet("getone/{IdState:int}")]
        public IActionResult Get(int IdState)
        {
            List<State> list = new List<State>();
            State state = new State();
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_GET_STATE", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            list.Add(new State()
                            {
                                IdState = Convert.ToInt32(rd["IdState"]),
                                NameState = rd["NameState"].ToString()
                            });
                        }
                    }
                }
                state = list.Where(item => item.IdState == IdState).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { message = "ok", response = state });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message, response = state });
            }
        }

        //Add state
        [HttpPost("addstate")]
        public IActionResult Save([FromBody] State state)
        {        
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_ADD_STATE", conexion);
                    cmd.Parameters.AddWithValue("NameState", state.NameState);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok"});                                    
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message, response = state });
            }
        }

        //Update State
        [HttpPut("update/{IdState:int}")]
        public IActionResult Update([FromBody] State state)
        {
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_UPDATE_STATE", conexion);
                    cmd.Parameters.AddWithValue("IdState", state.IdState == 0 ? DBNull.Value : state.IdState);
                    cmd.Parameters.AddWithValue("NameState", state.NameState is null ? DBNull.Value : state.NameState);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "State updated" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message, response = state });
            }
        }

        //Delete State
        [HttpDelete("delete/{IdState:int}")]
        public IActionResult Delete(int IdState)
        {
            try
            {
                using (var conexion = new SqlConnection(defaultConnection))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("SP_DELETE_STATE", conexion);
                    cmd.Parameters.AddWithValue("IdState", IdState);                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "State deleted" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = error.Message });
            }
        }
    }
}
