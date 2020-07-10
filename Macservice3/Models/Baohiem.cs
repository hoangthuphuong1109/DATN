namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Baohiem")]
    public partial class Baohiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Baohiem()
        {
            Chitietbaohiems = new HashSet<Chitietbaohiem>();
        }

        [Key]
        [StringLength(50)]
        public string Mabaohiem { get; set; }

        [StringLength(50)]
        public string Tenbaohiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbaohiem> Chitietbaohiems { get; set; }
    }
}
