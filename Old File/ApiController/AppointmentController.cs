using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.ServicesInterface;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagmentApi.ApiController
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        //[HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAll()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        //[HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        //[HttpPost("Add")]
        public async Task<ActionResult<Appointment>> Add(Appointment appointment)
        {
            var createdAppointment = await _appointmentService.AddAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetById), new { id = createdAppointment.Id }, createdAppointment);
        }

        //[HttpPatch("Update")]
        public async Task<ActionResult<Appointment>> Update(Appointment appointment)
        {
            var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(appointment);
            return Ok(updatedAppointment);
        }

        //[HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _appointmentService.DeleteAppointmentAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
