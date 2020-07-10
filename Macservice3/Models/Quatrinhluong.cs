namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quatrinhluong")]
    public partial class Quatrinhluong
    {
        [Key]
        [StringLength(50)]
        public string Maquatrinhluong { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        [StringLength(50)]
        public string Machucvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Thoigian { get; set; }

        public int? Luongcoban { get; set; }

        public int? Trocapchucvu { get; set; }

        public int? Phucapkhac { get; set; }

        [StringLength(50)]
        public string Noidung { get; set; }

        public int? Luongdoanhso { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
