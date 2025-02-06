using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace AppointmentManagmentApi.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class DoctorController : ControllerBase
    {
      

            private readonly IDoctorService _doctorService;

            public DoctorController(IDoctorService doctorService)
            {
            _doctorService = doctorService;
            }

            [HttpGet]
            [Route("GetDoctors")]
            public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
            {
                try
                {
                    var doctor = await _doctorService.GetAllDoctorAsync();

                    if (doctor == null || !doctor.Any())
                    {
                        return NotFound("No Users found.");
                    }

                    return Ok(doctor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while fetching user. Please try again later.");
                }
            }

            [HttpGet]
            [Route("GetDoctorById/{id}")]
            public async Task<ActionResult<Doctor>> GetDoctor(int id)
            {

                try
                {
                    var doctor = await _doctorService.GetDoctorByIdAsync(id);

                    if (doctor == null)
                    {
                        return NotFound($"doctor with ID {id} not found.");
                }

                    return Ok(doctor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while fetching the Doctor. Please try again later.");
                }
            }

            [HttpPost]
            [Route("CreateDoctor")]
            public async Task<ActionResult> CreateDoctor([FromBody] Doctor doctor)
            {
                try
                {
                    if (doctor == null)
                    {
                        return BadRequest("Doctor data is required.");
                    }

                    await _doctorService.AddDoctorAsync(doctor);

                    return CreatedAtAction(nameof(GetDoctor), new { id = doctor.Id }, doctor);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while creating the doctor. Please try again later.");
                }
            }


            [HttpPut]
            [Route("UpdateDoctor/{id}")]
            public async Task<ActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
            {
                try
                {
                    if (doctor == null)
                    {
                        return BadRequest("Doctor data is required.");
                    }

                    if (id != doctor.Id)
                    {
                        return BadRequest("Mismatched doctor ID.");
                    }

                    var existingDoctor = await _doctorService.GetDoctorByIdAsync(id);
                    if (existingDoctor == null)
                    {
                        return NotFound($"User with ID {id} not found.");
                    }

                    await _doctorService.UpdateDoctorAsync(doctor);

                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while updating the Doctor. Please try again later.");
                }
            }


            [HttpDelete]
            [Route("DeleteDoctorById/{id}")]
            public async Task<ActionResult> DeleteDoctor(int id)
            {
                try
                {
                    var existingDoctor = await _doctorService.GetDoctorByIdAsync(id);
                    if (existingDoctor == null)
                    {
                        return NotFound($"Doctor with ID {id} not found.");
                    }

                    await _doctorService.DeleteDoctorAsync(id);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while deleting the doctor. Please try again later.");
                }
            }

        }
    }
 
