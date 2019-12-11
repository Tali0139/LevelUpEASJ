namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientExercise")]
    public partial class ClientExercise
    {
        public int ClientExerciseId { get; set; }

        public int? ClientId { get; set; }

        public int? ExerciseId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Exercises Exercises { get; set; }
    }
}
