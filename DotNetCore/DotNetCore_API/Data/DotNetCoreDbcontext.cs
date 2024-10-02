using DotNetCore_API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_API.Data
{
    public class DotNetCoreDbcontext : DbContext
    {
        public DotNetCoreDbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed data for difficulty
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("ff373f74-3563-4ce0-82c0-99f0c065f738"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ee6159ac-8734-473c-a145-16c2e9f89960"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("4f0ef889-2941-493d-8fe7-0a9db0a56ed2"),
                    Name = "Hard",

                }
        };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //seed data for regions

            var regions = new List<Region>
            {
               new Region
                {
                    Id = Guid.Parse("9e4a3927-533c-48e2-8866-2f8f150df78e"),
                    Name = "Madurai",
                    Code="MDU",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },

                   new Region
                {
                    Id = Guid.Parse("dedf0bf4-074e-48ea-a46e-a7ad48ee67cb"),
                    Name = "Tiruchirappalli",
                    Code="TPJ",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                      new Region
                {
                    Id = Guid.Parse("c3b44ff9-3a3a-45e5-90cd-6345dfcc2d6c"),
                    Name = "Dindigul",
                    Code="DG",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                         new Region
                {
                    Id = Guid.Parse("6637ea22-e7a9-465d-9a98-f5226b0bc3bd"),
                    Name = "Thanjavur",
                    Code="TJ",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                           
               
                               new Region
                {
                    Id = Guid.Parse("a6c98bc3-381f-4826-86c6-e4b7f0877876"),
                    Name = "Chennai",
                    Code="CHN",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                                  new Region
                {
                    Id = Guid.Parse("c0ef2d24-a848-41c6-8e87-4066faed8bbf"),
                    Name = "Tiruvallur",
                    Code="TLR",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                                     new Region
                {
                    Id = Guid.Parse("e293c64f-bb48-4165-8f51-51d974e774d2"),
                    Name = "Rameswaram",
                    Code="RMM",
                    RegionImageUrl="https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528"
                },
                                        new Region
                {
                    Id = Guid.Parse("6b3066bb-856d-429c-b759-f11e7b1fe14f"),
                    Name = "Guduvancheri",
                    Code="GI",
                    RegionImageUrl= null
                },
                                           new Region
                {
                    Id = Guid.Parse("40070409-302c-4a4a-a43a-45a600381531"),
                    Name = "Tuticorin",
                    Code="TN",
                    RegionImageUrl=null
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);


        }
    }
}
