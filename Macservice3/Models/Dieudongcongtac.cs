namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dieudongcongtac")]
    public partial class Dieudongcongtac
    {
        [Key]
        [StringLength(50)]
        public string Malichtrinhcongtac { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        [StringLength(50)]
        public string Machucvu { get; set; }

        [StringLength(50)]
        public string Matrinhdochuyenmon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        [StringLength(50)]
        public string Noicongtac { get; set; }

        [StringLength(250)]
        public string Noidungcongtac { get; set; }

        public int? Trocap { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Phongban Phongban { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }

        public virtual Trinhdo_chuyenmon Trinhdo_chuyenmon { get; set; }
    }
}
