namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietchucvu")]
    public partial class Chitietchucvu
    {
        [Key]
        [StringLength(50)]
        public string Machitietchucvu { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Machucvu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tungay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Denngay { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
