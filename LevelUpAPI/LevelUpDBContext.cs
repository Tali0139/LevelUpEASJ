namespace LevelUpAPI
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
        public virtual DbSet<achievementGifts> achievementGifts { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientAppointment> ClientAppointment { get; set; }
        public virtual DbSet<ClientGifts> ClientGifts { get; set; }
        public virtual DbSet<ClientTraining> ClientTraining { get; set; }
        public virtual DbSet<ExperiencePoints> ExperiencePoints { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<LevelUp> LevelUp { get; set; }
        public virtual DbSet<Trainer> Trainer { get; set; }
        public virtual DbSet<TrainingExercise> TrainingExercise { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<achievementGifts>()
                .HasMany(e => e.ClientGifts)
                .WithOptional(e => e.achievementGifts)
                .HasForeignKey(e => e.GiftId);

            modelBuilder.Entity<Client>()
                .Property(e => e.Weight)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Client>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .Property(e => e.FatPercent)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Client)
                .WithRequired(e => e.User);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Trainer)
                .WithRequired(e => e.User);

            modelBuilder.Entity<LevelUp>()
                .HasMany(e => e.Client)
                .WithRequired(e => e.LevelUp)
                .WillCascadeOnDelete(false);
        }
    }
}
