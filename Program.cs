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

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the database connection
builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories and services
builder.Services.AddScoped<ILogin, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

// Add Authentication and JWT Token Configuration
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]); // Load the secret key securely from configuration
var securityKey = new SymmetricSecurityKey(key);
var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = false,
             ValidateAudience = false,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey"))
         };
     });


 


// Add Authorization with a custom policy
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

// Enable CORS - Allow any origin (change this for production)
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication(); // Use Authentication
app.UseAuthorization();  // Use Authorization
app.UseHttpsRedirection(); // Redirect HTTP to HTTPS
app.MapControllers(); // Map controllers
app.Run();
