namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietphongban")]
    public partial class Chitietphongban
    {
        [Key]
        [StringLength(50)]
        public string Machitietphongban { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
