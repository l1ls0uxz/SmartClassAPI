using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace SmartClassAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=Revision-PC\\STARDEV;Initial Catalog=SmartClassAPI;Integrated Security=True";

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            // create SQL connection
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // create SQL command to search for matching email and password
                string query = "SELECT * FROM [User] WHERE Email = @Email AND MatKhau = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                // open SQL connection
                connection.Open();

                // execute SQL command and return results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // email and password match a user in the database
                        int userId = reader.GetInt32("IdUser");
                        string message = "User match in database!.";
                        return Ok(new {message,userId});
                    }
                    else
                    {
                        // email and password do not match any user in the database
                        return BadRequest("Invalid email or password!.");
                    }
                }
            }
        }
    }
}