using Blogy.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccessLayer.Context
{
	public class BlogyContext : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-MT6QAH6\\SQLEXPRESS;initial catalog=DbBlogy;integrated Security=true;");
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Article> Articles { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Writer> Writers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
