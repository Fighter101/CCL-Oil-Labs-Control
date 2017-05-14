namespace CCL_Oil_Labs_Control.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyType> CompanyTypes { get; set; }
        public virtual DbSet<Furan> Furans { get; set; }
        public virtual DbSet<Gas> Gases { get; set; }
        public virtual DbSet<Lab> Labs { get; set; }
        public virtual DbSet<Oil> Oils { get; set; }
        public virtual DbSet<OilType> OilTypes { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transformer> Transformers { get; set; }
        public virtual DbSet<Turbine> Turbines { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OilAnalysisType> OilAnalysisTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(e => e.Stations)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => new { e.CompanyName, e.CompanyType })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CompanyType>()
                .HasMany(e => e.Companies)
                .WithRequired(e => e.CompanyType)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Furan>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Gas>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OilType>()
                .HasMany(e => e.Oils)
                .WithRequired(e => e.OilType)
                .HasForeignKey(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OilType>()
                .HasMany(e => e.Records)
                .WithOptional(e => e.OilType1)
                .HasForeignKey(e => e.OilType);

            modelBuilder.Entity<Record>()
                .Property(e => e.ImportDate)
                .HasPrecision(0);

            modelBuilder.Entity<Record>()
                .Property(e => e.ExportDate)
                .HasPrecision(0);

            modelBuilder.Entity<Record>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Record>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Furans)
                .WithOptional(e => e.Record)
                .HasForeignKey(e => e.PaperID);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Gases)
                .WithOptional(e => e.Record)
                .HasForeignKey(e => e.PaperID);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Transformers)
                .WithOptional(e => e.Record)
                .HasForeignKey(e => e.PaperID);

            modelBuilder.Entity<Record>()
                .HasMany(e => e.Turbines)
                .WithOptional(e => e.Record)
                .HasForeignKey(e => e.PaperID);

            modelBuilder.Entity<Station>()
                .HasMany(e => e.Records)
                .WithOptional(e => e.Station1)
                .HasForeignKey(e => new { e.Station, e.CompanyType, e.Company });

            modelBuilder.Entity<Transformer>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<Turbine>()
                .Property(e => e.SSMA_TimeStamp)
                .IsFixedLength();
        }
    }
}
