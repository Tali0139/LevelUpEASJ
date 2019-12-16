namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LevelValue { get; set; }

        public int MinXP { get; set; }

        public int MaxXP { get; set; }

        [Required]
        [StringLength(50)]
        public string Gave { get; set; }
    }
}
