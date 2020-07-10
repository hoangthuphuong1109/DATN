namespace Macservice3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thongtinnhansu")]
    public partial class Thongtinnhansu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thongtinnhansu()
        {
            Chitietbangcongs = new HashSet<Chitietbangcong>();
            Chitietbaohiems = new HashSet<Chitietbaohiem>();
            Chitietchucvus = new HashSet<Chitietchucvu>();
            Chitietkhenthuongs = new HashSet<Chitietkhenthuong>();
            Chitietkyluats = new HashSet<Chitietkyluat>();
            Chitietphongbans = new HashSet<Chitietphongban>();
            Chitiettrinhdochuyenmons = new HashSet<Chitiettrinhdochuyenmon>();
            Dieudongcongtacs = new HashSet<Dieudongcongtac>();
            Hopdongs = new HashSet<Hopdong>();
            Quatrinhluongs = new HashSet<Quatrinhluong>();
        }

        [Key]
        [StringLength(50)]
        public string Manv { get; set; }

        [StringLength(50)]
        public string Hoten { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Ngaysinh { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string Gioitinh { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Dantoc { get; set; }

        [StringLength(250)]
        public string Noisinh { get; set; }

        [StringLength(250)]
        public string Hokhauthuongtru { get; set; }

        [StringLength(250)]
        public string Noiohientai { get; set; }

        public int? CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaycap { get; set; }

        [StringLength(50)]
        public string Noicap { get; set; }

        [StringLength(50)]
        public string Maphongban { get; set; }

        [StringLength(50)]
        public string Machucvu { get; set; }

        [StringLength(50)]
        public string Matrinhdochuyenmon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbangcong> Chitietbangcongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietbaohiem> Chitietbaohiems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietchucvu> Chitietchucvus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkhenthuong> Chitietkhenthuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietkyluat> Chitietkyluats { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitietphongban> Chitietphongbans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chitiettrinhdochuyenmon> Chitiettrinhdochuyenmons { get; set; }

        public virtual Chucvu Chucvu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dieudongcongtac> Dieudongcongtacs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hopdong> Hopdongs { get; set; }

        public virtual Phongban Phongban { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quatrinhluong> Quatrinhluongs { get; set; }

        public virtual Trinhdo_chuyenmon Trinhdo_chuyenmon { get; set; }
    }
}
