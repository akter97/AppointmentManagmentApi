using Microsoft.AspNetCore.Mvc;

namespace AppointmentManagmentApi.ApiController
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
