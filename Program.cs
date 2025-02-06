
using AppointmentManagmentApi._2AppointmentRepository;
using AppointmentManagmentApi._2AppointmentRepositoryI;
using AppointmentManagmentApi._2Service;
using AppointmentManagmentApi._2ServiceI;
using AppointmentManagmentApi.DataConnection.AppointmentManagmentApi.DataConnection;
using AppointmentManagmentApi.Repository;
using AppointmentManagmentApi.RepositoryInterface;
using AppointmentManagmentApi.Service;
using AppointmentManagmentApi.ServiceInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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


// Add Authentication 
 
var key = new byte[32]; // 256 bits
using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
{
    rng.GetBytes(key); // Generate a random 256-bit key
}
var securityKey = new SymmetricSecurityKey(key);
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = securityKey,
        };
    });
 


// Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

// connection Framework
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
app.UseAuthentication();
app.UseAuthorization(); 
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

