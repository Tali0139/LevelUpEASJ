namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Trainer")]
    public partial class Trainer
    {
        public int Id { get; set; }

        public int? YearsOfExpericence { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public int? PhoneNumber { get; set; }

        [StringLength(50)]
        public string Image { get; set; }
    }
}
