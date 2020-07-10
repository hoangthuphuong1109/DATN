namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kyluat")]
    public partial class Kyluat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kyluat()
        {
            Chitietkyluats = new HashSet<Chitietkyluat>();
        }

        [Key]
        [StringLength(50)]
        public string Makyluat { get; set; }

        [StringLength(50)]
        public string Tenkyluat { get; set; }

        [StringLength(50)]
        public string Quyetdinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkyluat> Chitietkyluats { get; set; }
    }
}
