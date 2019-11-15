namespace WebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal Weight { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public decimal FatPercent { get; set; }

        public int ClientXp { get; set; }

        public int ClientLevel { get; set; }

        public int Height { get; set; }
    }
}
