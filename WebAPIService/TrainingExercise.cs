namespace WebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrainingExercise")]
    public partial class TrainingExercise
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? Squat { get; set; }

        public int? Run { get; set; }

        public int? SitUps { get; set; }

        public int? Planking { get; set; }

        public int? PushUps { get; set; }

        public int? BicepsCurts { get; set; }

        public int? TricepsPushdowns { get; set; }
    }
}
