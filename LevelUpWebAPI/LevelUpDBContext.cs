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
        public virtual DbSet<achievementGift> achievementGifts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAppointment> ClientAppointments { get; set; }
        public virtual DbSet<ClientGift> ClientGifts { get; set; }
        public virtual DbSet<ClientTraining> ClientTrainings { get; set; }
        public virtual DbSet<ExperiencePoint> ExperiencePoints { get; set; }
        public virtual DbSet<LevelUp> LevelUps { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TrainingExercise> TrainingExercises { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<achievementGift>()
                .HasMany(e => e.ClientGifts)
                .WithOptional(e => e.achievementGift)
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

            modelBuilder.Entity<LevelUp>()
                .HasMany(e => e.achievementGifts)
                .WithOptional(e => e.LevelUp)
                .WillCascadeOnDelete();

            modelBuilder.Entity<LevelUp>()
                .HasMany(e => e.Clients)
                .WithRequired(e => e.LevelUp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Client)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.ClientAppointments)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Trainer)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
