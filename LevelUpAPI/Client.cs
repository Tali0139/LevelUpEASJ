namespace LevelUpAPI
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
            ClientGifts = new HashSet<ClientGifts>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public decimal Weight { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public decimal FatPercent { get; set; }

        public int TotalXp { get; set; }

        public int Level { get; set; }

        public int Height { get; set; }

        public virtual IUser IUser { get; set; }

        public virtual LevelUp LevelUp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientGifts> ClientGifts { get; set; }
    }
}
