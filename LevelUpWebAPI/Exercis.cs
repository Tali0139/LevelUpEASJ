namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercises")]
    public partial class Exercis
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercis()
        {
            ClientExercises = new HashSet<ClientExercise>();
        }

        [Required]
        [StringLength(50)]
        public string ExerciseName { get; set; }

        public int XpForExercise { get; set; }

        [Key]
        public int ExerciseId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientExercise> ClientExercises { get; set; }
    }
}
