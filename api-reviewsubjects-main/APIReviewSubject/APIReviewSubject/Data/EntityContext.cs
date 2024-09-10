using APIReviewSubject.Models;
using Microsoft.EntityFrameworkCore;

namespace APIReviewSubject.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options) { }

        public EntityContext() { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        /// <summary>
        /// Update Database
        /// </summary>
        /// <param name="context"></param>
        public static void UpdateDatabase(EntityContext context)
        {
            context.Database.Migrate();
        }

        /// <summary>
        /// Configure Database
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var sqlConnection = "Server=localhost;Port=3306;Database=reviewsubject;Uid=root;Pwd=1234$;MaximumPoolSize=500;";
                optionsBuilder.UseMySql(sqlConnection,
                    MySqlServerVersion.LatestSupportedServerVersion);
            }
        }
    }
}
