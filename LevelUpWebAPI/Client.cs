namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            ClientExercises = new HashSet<ClientExercise>();
        }

        public int Id { get; set; }

        public int? Height { get; set; }

        public decimal? Weight { get; set; }

        public decimal? FatPercentage { get; set; }

        public int? Age { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        public int? WaistSize { get; set; }

        public decimal? ArmSize { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? PhoneNumber { get; set; }

        public int? TotalXP { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientExercise> ClientExercises { get; set; }
    }
}
