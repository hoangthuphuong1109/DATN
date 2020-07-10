namespace Macservice3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Macservice : DbContext
    {
        public Macservice()
            : base("name=Macservice3")
        {
        }

        public virtual DbSet<Bangchamcong> Bangchamcongs { get; set; }
        public virtual DbSet<Baohiem> Baohiems { get; set; }
        public virtual DbSet<Chitietbangcong> Chitietbangcongs { get; set; }
        public virtual DbSet<Chitietbaohiem> Chitietbaohiems { get; set; }
        public virtual DbSet<Chitietchucvu> Chitietchucvus { get; set; }
        public virtual DbSet<Chitietkhenthuong> Chitietkhenthuongs { get; set; }
        public virtual DbSet<Chitietkyluat> Chitietkyluats { get; set; }
        public virtual DbSet<Chitietphongban> Chitietphongbans { get; set; }
        public virtual DbSet<Chitiettrinhdochuyenmon> Chitiettrinhdochuyenmons { get; set; }
        public virtual DbSet<Chucvu> Chucvus { get; set; }
        public virtual DbSet<Dieudongcongtac> Dieudongcongtacs { get; set; }
        public virtual DbSet<Hopdong> Hopdongs { get; set; }
        public virtual DbSet<Khenthuong> Khenthuongs { get; set; }
        public virtual DbSet<Kyluat> Kyluats { get; set; }
        public virtual DbSet<Loaihopdong> Loaihopdongs { get; set; }
        public virtual DbSet<Phongban> Phongbans { get; set; }
        public virtual DbSet<Quatrinhluong> Quatrinhluongs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Taikhoan> Taikhoans { get; set; }
        public virtual DbSet<Thongtinnhansu> Thongtinnhansus { get; set; }
        public virtual DbSet<Trinhdo_chuyenmon> Trinhdo_chuyenmon { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
