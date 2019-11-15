namespace WebAPIService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class achievementGift
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string GiftItem { get; set; }

        public decimal? Price { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public int? ItemsInInventory { get; set; }
    }
}
