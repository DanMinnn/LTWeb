﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestTemplate.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLDSEntities : DbContext
    {
        public QLDSEntities()
            : base("name=QLDSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CoSo> CoSoes { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DanhMucSan> DanhMucSans { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LichDat> LichDats { get; set; }
        public virtual DbSet<LoaiCoSo> LoaiCoSoes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhanCong> PhanCongs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<QuanTriVien> QuanTriViens { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<San> Sans { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<user_KhachHang> user_KhachHang { get; set; }
    }
}