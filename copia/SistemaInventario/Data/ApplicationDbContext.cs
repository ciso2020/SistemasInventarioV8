using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SistemaInventario.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
