using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogsApi.Models
{
    public class BlogDBContext : IdentityDbContext<Users, IdentityRole<int>, int>
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> opt) : base(opt)
        {

        }
        public DbSet<BlogsM> Blogs { get; set; }
        //public DbSet<Users> Users{ get; set; }
        public DbSet<Comments> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
               .HasMany(o => o.BlogsM)
               .WithOne()
               .HasForeignKey(d => d.AuthorId)
               .IsRequired();
           
                        modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(85));

                        modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(85));
                        modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(85));

                        modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserLogin<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));

                        modelBuilder.Entity<IdentityUserRole<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));

                        modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserToken<int>>(entity => entity.Property(m => m.Name).HasMaxLength(85));

                        modelBuilder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
                        modelBuilder.Entity<IdentityUserClaim<int>>(entity => entity.Property(m => m.UserId).HasMaxLength(85));
                        modelBuilder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.Id).HasMaxLength(85));
                        modelBuilder.Entity<IdentityRoleClaim<int>>(entity => entity.Property(m => m.RoleId).HasMaxLength(85));


           




        }


    }
}
