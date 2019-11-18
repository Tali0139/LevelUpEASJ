namespace LevelUpAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientTraining")]
    public partial class ClientTraining
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CTId { get; set; }

        public int? AppointmentId { get; set; }

        public int? ExerciseId { get; set; }

        public virtual ClientAppointment ClientAppointment { get; set; }

        public virtual TrainingExercise TrainingExercise { get; set; }
    }
}
