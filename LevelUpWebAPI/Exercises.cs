namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exercises
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercises()
        {
            ClientExercise = new HashSet<ClientExercise>();
        }

        [Required]
        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int XpForExercise { get; set; }

        [Key]
        public int ExerciseId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientExercise> ClientExercise { get; set; }
    }
}
