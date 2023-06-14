using FirstApp_CRUD.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace FirstApp_CRUD.Data
{
   
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }

}
