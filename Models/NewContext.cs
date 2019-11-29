using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class NewContext : DbContext
    {
        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Blogsdb;Integrated Security=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(e => e.ID); //set key

            modelBuilder.Entity<Post>(b =>
            {
                b.HasKey(e => e.ID);
                b.Property(e => e.ID).ValueGeneratedOnAdd();
            });//key tự động tăng

            modelBuilder.Entity<Category>().HasKey(e => e.ID);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)//1 Cate có nhiều Post
                .WithOne(e => e.Category);//Trong 1 post đó sẽ có duy nhất 1 Category

            modelBuilder.Entity<Post>()
                .Property(e => e.ViewCount)
                .HasDefaultValue(0);//xét ViewCount = 0




        }
    }
}
