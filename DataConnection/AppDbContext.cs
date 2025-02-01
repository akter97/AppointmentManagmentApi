namespace AppointmentManagmentApi.DataConnection
{ 
    using Microsoft.EntityFrameworkCore; 
    using global::AppointmentManagmentApi.Models;

    namespace AppointmentManagmentApi.DataConnection
    {
        public class AppDbContext : DbContext   
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            } 
             public DbSet<User> Users { get; set; }  
        }
    }

}
