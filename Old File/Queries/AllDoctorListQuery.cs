using AppointmentManagmentApi.Models;
using AppointmentManagmentApi.Services;
using AppointmentManagmentApi.ServicesInterface;
using MediatR;

namespace AppointmentManagmentApi.Queries
{
    
        public class AllDoctorListQuery : IRequest<List<Doctor>>
        {
            public int Id { get; set; } 
        public class Handler : IRequestHandler<AllDoctorListQuery, List<Doctor>>
        {
            private readonly IDoctorServices _service;
            public Handler(IDoctorServices service)
            {
                _service = service;

            }

            public async Task<List<Doctor>> Handle(AllDoctorListQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.AllDoctorListQuery( request.Id);
                return result;
            }
        }
    }
}
