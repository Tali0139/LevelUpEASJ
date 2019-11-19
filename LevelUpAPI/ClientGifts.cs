namespace LevelUpAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClientGifts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CGId { get; set; }

        public int? Id { get; set; }

        public int? GiftId { get; set; }

        public virtual achievementGifts achievementGifts { get; set; }

        public virtual Client Client { get; set; }
    }
}
