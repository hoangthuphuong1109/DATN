namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietbaohiem")]
    public partial class Chitietbaohiem
    {
        [Key]
        [StringLength(50)]
        public string Machitietbaohiem { get; set; }

        [StringLength(50)]
        public string Mabaohiem { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Baohiem Baohiem { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
