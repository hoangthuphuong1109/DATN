namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietkyluat")]
    public partial class Chitietkyluat
    {
        [Key]
        [StringLength(50)]
        public string Machitietkyluat { get; set; }

        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Makyluat { get; set; }

        [StringLength(250)]
        public string Lydokyluat { get; set; }

        public int? Tienphat { get; set; }

        public virtual Kyluat Kyluat { get; set; }

        public virtual Thongtinnhansu Thongtinnhansu { get; set; }
    }
}
