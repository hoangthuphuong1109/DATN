namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bangchamcong")]
    public partial class Bangchamcong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bangchamcong()
        {
            Chitietbangcongs = new HashSet<Chitietbangcong>();
        }

        [Key]
        [StringLength(50)]
        public string Mabangcong { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        public int? Thangchamcong { get; set; }

        public int? Nam { get; set; }

        public virtual Phongban Phongban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbangcong> Chitietbangcongs { get; set; }
    }
}
