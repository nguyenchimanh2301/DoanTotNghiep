using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<bill_detail_ban> bill_detail_ban { get; set; }
        public virtual DbSet<bill_detail_nhap> bill_detail_nhap { get; set; }
        public virtual DbSet<bills_ban> bills_ban { get; set; }
        public virtual DbSet<bills_nhap> bills_nhap { get; set; }
        public virtual DbSet<khach_hang> khach_hang { get; set; }
        public virtual DbSet<loai_sp> loai_sp { get; set; }
        public virtual DbSet<san_pham> san_pham { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<nha_cung_cap> nha_cung_cap { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bill_detail_ban>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_ban>()
                .Property(e => e.id_bill_ban)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_ban>()
                .Property(e => e.id_kh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_nhap>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_nhap>()
                .Property(e => e.id_bill_nhap)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_nhap>()
                .Property(e => e.id_sp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bill_detail_nhap>()
                .Property(e => e.don_vi)
                .IsUnicode(false);

            modelBuilder.Entity<bills_ban>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bills_ban>()
                .Property(e => e.id_kh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bills_ban>()
                .Property(e => e.trangthai)
                .IsUnicode(false);

            modelBuilder.Entity<bills_ban>()
                .Property(e => e.ten_kh)
                .IsUnicode(false);

            modelBuilder.Entity<bills_nhap>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bills_nhap>()
                .Property(e => e.id_ncc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bills_nhap>()
                .Property(e => e.id_nhanvien)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<bills_nhap>()
                .Property(e => e.thanh_toan)
                .IsUnicode(false);

            modelBuilder.Entity<bills_nhap>()
                .HasMany(e => e.bill_detail_nhap)
                .WithRequired(e => e.bills_nhap)
                .HasForeignKey(e => e.id_bill_nhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.ten_kh)
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.dia_chi)
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.sdt)
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<khach_hang>()
                .HasMany(e => e.bills_ban)
                .WithOptional(e => e.khach_hang)
                .HasForeignKey(e => e.id_kh);

            modelBuilder.Entity<loai_sp>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<loai_sp>()
                .HasMany(e => e.san_pham)
                .WithOptional(e => e.loai_sp)
                .HasForeignKey(e => e.id_loai_sp);

            modelBuilder.Entity<san_pham>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<san_pham>()
                .Property(e => e.id_loai_sp)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<san_pham>()
                .Property(e => e.id_ncc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<san_pham>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<san_pham>()
                .Property(e => e.don_vi_tinh)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.id_new)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<news>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<nha_cung_cap>()
                .Property(e => e.id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<nha_cung_cap>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<nha_cung_cap>()
                .Property(e => e.sdt)
                .IsUnicode(false);
        }
    }
}
