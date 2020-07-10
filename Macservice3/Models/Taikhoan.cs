namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Taikhoan")]
    public partial class Taikhoan
    {
        [Key]
        [StringLength(50)]
        public string Mataikhoan { get; set; }

        [StringLength(50)]
        public string Tendangnhap { get; set; }

        [StringLength(50)]
        public string Matkhau { get; set; }

        [StringLength(50)]
        public string Role_id { get; set; }

        public virtual Role Role { get; set; }
    }
}
