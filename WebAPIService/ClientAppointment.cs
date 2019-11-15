namespace WebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClientAppointment")]
    public partial class ClientAppointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("ClientAppointment")]
        [StringLength(50)]
        public string ClientAppointment1 { get; set; }

        [StringLength(10)]
        public string Exercise { get; set; }
    }
}
