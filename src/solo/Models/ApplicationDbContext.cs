using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace solo.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Board> DbBoards { get; set; }

        public DbSet<Post> DbPosts { get; set; }

        public DbSet<Comment> DbComments { get; set; }

        public DbSet<User> DbUsers { get; set; }

        public DbSet<Admin> DbAdmins { get; set; }

        public DbSet<Edit> DbEdits { get; set; }

        public DbSet<Tag> DbTags { get; set; }

        public DbSet<Vote> DbVotes { get; set; }
    }
}
