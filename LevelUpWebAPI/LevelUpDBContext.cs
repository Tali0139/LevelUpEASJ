namespace LevelUpWebAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LevelUpDBContext : DbContext
    {
        public LevelUpDBContext()
            : base("name=LevelUpDBContext")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.FatPercentage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.ArmSize)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Trainer>()
                .Property(e => e.Username)
                .IsUnicode(false);
        }
    }
}
