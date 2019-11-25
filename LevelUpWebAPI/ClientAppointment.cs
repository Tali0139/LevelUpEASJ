namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientAppointment")]
    public partial class ClientAppointment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientAppointment()
        {
            ClientTrainings = new HashSet<ClientTraining>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppointmentId { get; set; }

        public TimeSpan? Time { get; set; }

        public int? NoOfReps1 { get; set; }

        [Column("Reps Completed1")]
        public int? Reps_Completed1 { get; set; }

        public int? Id { get; set; }

        public DateTime? Date { get; set; }

        public int? XpEarned { get; set; }

        public virtual ExperiencePoint ExperiencePoint { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientTraining> ClientTrainings { get; set; }
    }
}
