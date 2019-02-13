namespace PlacementData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .Property(e => e.BranchName)
                .IsFixedLength();

            modelBuilder.Entity<Section>()
                .Property(e => e.SectionName)
                .IsFixedLength();
        }
    }
}
