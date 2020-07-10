namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hopdong")]
    public partial class Hopdong
    {
        [Key]
        [StringLength(50)]
        public string Mahopdong { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Maloaihopdong { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Ngaykyket { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Ngayketthuc { get; set; }

        public int? Luongcoban { get; set; }

        public virtual Loaihopdong Loaihopdong { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
