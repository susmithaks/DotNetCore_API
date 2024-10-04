using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_API.Data
{
    public class DotNetCoreAuthDbcontext : IdentityDbContext
    {
       
      public DotNetCoreAuthDbcontext(DbContextOptions<DotNetCoreAuthDbcontext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "043f3b41-6ea1-45aa-8333-9e28622ccce5";
            var writerRoleId = "59efcb1c-4ae3-4e19-b952-bb80fcc3f604";
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id =readerRoleId,
                    ConcurrencyStamp=readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id= writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
