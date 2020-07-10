namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietbangcong")]
    public partial class Chitietbangcong
    {
        [Key]
        [StringLength(50)]
        public string Machitietbangcong { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Mabangcong { get; set; }

        public double? Sogiolam { get; set; }

        public double? Sogiolamthemngaythuong { get; set; }

        public double? Sogiolamthemngaynghi { get; set; }

        public double? Sogiolamthemngayle { get; set; }

        public double? Songaynghiphep { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        public virtual Bangchamcong Bangchamcong { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
