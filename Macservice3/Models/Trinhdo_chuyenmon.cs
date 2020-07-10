namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trinhdo_chuyenmon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Trinhdo_chuyenmon()
        {
            Chitiettrinhdochuyenmons = new HashSet<Chitiettrinhdochuyenmon>();
            Dieudongcongtacs = new HashSet<Dieudongcongtac>();
            Thongtinnhansus = new HashSet<Thongtinnhansu>();
        }

        [Key]
        [StringLength(50)]
        public string Matrinhdochuyenmon { get; set; }

        [StringLength(50)]
        public string Tentrinhdochuyenmon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiettrinhdochuyenmon> Chitiettrinhdochuyenmons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dieudongcongtac> Dieudongcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thongtinnhansu> Thongtinnhansus { get; set; }
    }
}
