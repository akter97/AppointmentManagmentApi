
using AppointmentManagmentApi._2ServiceI;
using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppointmentManagmentApi._2Api
{ 
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet] 
         [Route("GetAppointments")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments()
        { 
            try
            {
                var appointments = await _appointmentService.GetAllAppointmentsAsync();

                if (appointments == null || !appointments.Any())
                {
                    return NotFound("No appointments found.");
                }

                return Ok(appointments);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(500, "An error occurred while fetching appointments. Please try again later.");
            }
        }
         
        [HttpGet]
        [Route("GetAppointmentById/{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
             
                try
                {
                    var appointment = await _appointmentService.GetAppointmentByIdAsync(id);

                    if (appointment == null)
                    {
                        return NotFound($"Appointment with ID {id} not found.");
                    }

                    return Ok(appointment);
                }
                catch (Exception ex)
                { 
                    Console.WriteLine($"Error: {ex.Message}");

                    return StatusCode(500, "An error occurred while fetching the appointment. Please try again later.");
                }
            }

        [HttpPost]
        [Route("CreateAppointment")]
        public async Task<ActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("Appointment data is required.");
                }

                await _appointmentService.AddAppointmentAsync(appointment);

                return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, appointment);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(500, "An error occurred while creating the appointment. Please try again later.");
            }
        }


        [HttpPut]
        [Route("UpdateAppointment/{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            try
            {
                if (appointment == null)
                {
                    return BadRequest("Appointment data is required.");
                }

                if (id != appointment.Id)
                {
                    return BadRequest("Mismatched appointment ID.");
                }

                var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
                if (existingAppointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                await _appointmentService.UpdateAppointmentAsync(appointment);

                return NoContent();  
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(500, "An error occurred while updating the appointment. Please try again later.");
            }
        }


        [HttpDelete]
        [Route("DeleteAppointmentById/{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            try
            {
                var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
                if (existingAppointment == null)
                {
                    return NotFound($"Appointment with ID {id} not found.");
                }

                await _appointmentService.DeleteAppointmentAsync(id);
                return NoContent();  
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"Error: {ex.Message}");

                return StatusCode(500, "An error occurred while deleting the appointment. Please try again later.");
            }
        }

    }

}