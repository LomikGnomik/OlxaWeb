using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OlxaWeb.Domain.Concrete
{
   public class EFDbContext:DbContext
    {
        public EFDbContext() : base()
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(
             new DropCreateDatabaseIfModelChanges<EFDbContext>());
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Temmplate> Temmplates { get; set; }
        public DbSet<WebSite> WebSites { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)   // Для связи многие ко многим
        {
            modelBuilder.Entity<Post>().HasMany(c => c.Tags)
                .WithMany(s => s.Posts)
                .Map(t => t.MapLeftKey("Post_Id")
                .MapRightKey("Tag_Id")
                .ToTable("TagPosts"));
        }

    }
}
