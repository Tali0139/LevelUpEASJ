namespace LevelUpDBWebAPI
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
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<User> Users { get; set; }

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

            modelBuilder.Entity<Trainer>()
                .Property(e => e.YearsOfExpericence)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Client)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Trainer)
                .WithRequired(e => e.User);
        }
    }
}
