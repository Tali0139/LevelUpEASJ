namespace WebAPIService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LevelDBContext : DbContext
    {
        public LevelDBContext()
            : base("name=LevelDBContext")
        {
        }

        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<achievementGift> achievementGifts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAppointment> ClientAppointments { get; set; }
        public virtual DbSet<ClientTraining> ClientTrainings { get; set; }
        public virtual DbSet<LevelUp> LevelUps { get; set; }
        public virtual DbSet<TrainingExercise> TrainingExercises { get; set; }
        public virtual DbSet<TrainingLevel> TrainingLevels { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<achievementGift>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<achievementGift>()
                .Property(e => e.DiscountPercentage)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.FatPercent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ClientAppointment>()
                .Property(e => e.Exercise)
                .IsFixedLength();

            modelBuilder.Entity<LevelUp>()
                .Property(e => e.XpEarned)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TrainingLevel>()
                .Property(e => e.XPEarnedByExercise)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsFixedLength();
        }
    }
}
