using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=TEXAST5\\SQLEXPRESS;database=DotRestaurant;integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<BookTableModel> bookTableModels { get; set; }
        public DbSet<FoodModel> foodModels { get; set; }
        public DbSet<CategoryModel> categoryModels { get; set; }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<CartModel> cartModels { get; set; }

    }
}
