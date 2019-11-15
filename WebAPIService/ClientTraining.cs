namespace WebAPIService
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
        public int ExerciseId { get; set; }

        [StringLength(50)]
        public string TrainingType { get; set; }
    }
}
