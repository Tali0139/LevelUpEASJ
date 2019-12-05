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
        [Column("Level")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Level1 { get; set; }

        public int MinXP { get; set; }

        public int MaxXP { get; set; }
    }
}
