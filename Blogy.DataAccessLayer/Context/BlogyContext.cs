using Blogy.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Context
{
    public class BlogyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-MT6QAH6\\SQLEXPRESS;initial catalog=DbBlogy;integrated Security=true;");
        }

        public DbSet<Category> Categories { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Writer> Writers { get; set; }

    }
}
