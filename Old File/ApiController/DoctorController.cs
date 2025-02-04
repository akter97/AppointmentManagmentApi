using AppointmentManagmentApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagmentApi.ApiController
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class DoctorController : Controller
    {
        private IMediator _mediator;
        protected IMediator _mediatr => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //[HttpGet("GetAllDoctorList/{Id}")]
        public async Task<IActionResult> GetAllDoctorList(int Id)
        {
            try
            {
                return Ok(await _mediatr.Send(new AllDoctorListQuery { Id = Id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
