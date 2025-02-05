
using AppointmentManagmentApi._2AppointmentRepository;
using AppointmentManagmentApi._2AppointmentRepositoryI;
using AppointmentManagmentApi._2Service;
using AppointmentManagmentApi._2ServiceI;
using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Repository;
using AppointmentManagmentApi.RepositoryInterface;
using AppointmentManagmentApi.Service;
using AppointmentManagmentApi.ServiceInterface; 
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args); 
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
 
var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

