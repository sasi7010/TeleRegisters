using Microsoft.EntityFrameworkCore;
using TeleRegister.Models;

namespace TeleRegister.Data
{
    public class DBContext:DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { 
        }
        public DbSet<Register> Register { get; set; } = null!;
        public DbSet<Patient> Patient { get; set; } = null!;
        public DbSet<Doctor> Doctor { get; set; } = null!;
    }
}
