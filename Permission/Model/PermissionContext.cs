using Microsoft.EntityFrameworkCore;

namespace Permission.Model
{
    public class PermissionContext:DbContext
    {
        public PermissionContext(DbContextOptions<PermissionContext> options) : base(options)
        {

        }

        public DbSet<Manger> mangers { get; set; }
        public DbSet<Department> departments { get; set; }

        public DbSet<WorkPermitRequest> workPermitRequests { get; set; }
    }
}
