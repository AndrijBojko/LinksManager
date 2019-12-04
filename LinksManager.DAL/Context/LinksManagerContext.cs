using LinksManager.Entities;

namespace LinksManager.DAL.Context
{
    using System.Data.Entity;


    public partial class LinksManagerContext : DbContext
    {
        public LinksManagerContext()
            : base("name=LinksManagerContext")
        {
        }

        public virtual DbSet<Link> Link { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
