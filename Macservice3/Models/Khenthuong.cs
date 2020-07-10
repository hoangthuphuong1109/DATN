namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khenthuong")]
    public partial class Khenthuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khenthuong()
        {
            Chitietkhenthuongs = new HashSet<Chitietkhenthuong>();
        }

        [Key]
        [StringLength(50)]
        public string Makhenthuong { get; set; }

        [Required]
        [StringLength(50)]
        public string Tenkhenthuong { get; set; }

        [Required]
        [StringLength(50)]
        public string Quyetdinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkhenthuong> Chitietkhenthuongs { get; set; }
    }
}
