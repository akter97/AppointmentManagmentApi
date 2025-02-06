using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppointmentManagmentApi.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
      
          private readonly IUserService _userService; 

    public UserController(IUserService userService )
    {
        _userService = userService; 
    }



    [HttpGet]
            [Route("GetUsers")]
            public async Task<ActionResult<IEnumerable<User>>> GetUsers()
            {
                try
                {
                    var user = await _userService.GetAllUserAsync();

                    if (user == null || !user.Any())
                    {
                        return NotFound("No Users found.");
                    }

                    return Ok(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while fetching user. Please try again later.");
                }
            }

            [HttpGet]
            [Route("GetUserById/{id}")]
            public async Task<ActionResult<User>> GetUser(int id)
            {

                try
                {
                    var user = await _userService.GetUserByIdAsync(id);

                    if (user == null)
                    {
                        return NotFound($"User with ID {id} not found.");
                    }

                    return Ok(user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while fetching the user. Please try again later.");
                }
            }

            [HttpPost]
            [Route("CreateUser")]
            public async Task<ActionResult> CreateUser([FromBody] User user)
            {
                try
                {
                    if (user == null)
                    {
                        return BadRequest("User data is required.");
                    }

                    await _userService.AddUserAsync(user);

                    return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while creating the user. Please try again later.");
                }
            }


            [HttpPut]
            [Route("UpdateUser/{id}")]
            public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
            {
                try
                {
                    if (user == null)
                    {
                        return BadRequest("User data is required.");
                    }

                    if (id != user.Id)
                    {
                        return BadRequest("Mismatched user ID.");
                    }

                    var existingUser = await _userService.GetUserByIdAsync(id);
                    if (existingUser == null)
                    {
                        return NotFound($"User with ID {id} not found.");
                    }

                    await _userService.UpdateUserAsync(user);

                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while updating the user. Please try again later.");
                }
            }


            [HttpDelete]
            [Route("DeleteUserById/{id}")]
            public async Task<ActionResult> DeleteUser(int id)
            {
                try
                {
                    var existingUser = await _userService.GetUserByIdAsync(id);
                    if (existingUser == null)
                    {
                        return NotFound($"User with ID {id} not found.");
                    }

                    await _userService.DeleteUserAsync(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while deleting the user. Please try again later.");
                }
            }

        }
    }