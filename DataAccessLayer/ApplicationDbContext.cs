using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {


        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-CSE2LTTD\SQLEXPRESS; Initial Catalog=MVCBlogDb; Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().Property(a => a.UserFirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<UserDetail>().Property(a => a.UserSurname).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<User>().Property(a => a.UserMail).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.ArticleHeading).HasMaxLength(30).IsRequired();
            modelBuilder.Entity<User>().Property(a => a.Password).IsRequired();
            modelBuilder.Entity<UserDetail>().Ignore(a => a.UserPhoto);

            modelBuilder.Entity<User>().HasMany(a => a.ArticlesLiked).WithMany(b => b.UserLiked);
            modelBuilder.Entity<User>().HasMany(a => a.Articles).WithOne(b => b.User).HasForeignKey(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
