namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietkhenthuong")]
    public partial class Chitietkhenthuong
    {
        [Key]
        [StringLength(50)]
        public string Machitietkhenthuong { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Makhenthuong { get; set; }

        [StringLength(250)]
        public string Lydokhenthuong { get; set; }

        public int? Tienthuong { get; set; }

        public virtual Khenthuong Khenthuong { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
