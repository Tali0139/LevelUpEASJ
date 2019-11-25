namespace LevelUpWebAPI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class achievementGift
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public achievementGift()
        {
            ClientGifts = new HashSet<ClientGift>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GiftItemId { get; set; }

        [StringLength(50)]
        public string NameOfGift { get; set; }

        public int? Level { get; set; }

        public int? ItemsInInventory { get; set; }

        public virtual LevelUp LevelUp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientGift> ClientGifts { get; set; }
    }
}
