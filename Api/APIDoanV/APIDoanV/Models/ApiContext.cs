using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Models;

public partial class ApiContext : DbContext
{
    public ApiContext()
    {
    }

    public ApiContext(DbContextOptions<ApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<BillDetailBan> BillDetailBans { get; set; }

    public virtual DbSet<BillDetailNhap> BillDetailNhaps { get; set; }

    public virtual DbSet<BillsBan> BillsBans { get; set; }

    public virtual DbSet<BillsNhap> BillsNhaps { get; set; }

    public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

    public virtual DbSet<Donhang> Donhangs { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSp> LoaiSps { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-LLHPT87U\\SQLEXPRESS;Database=API;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan);

            entity.ToTable("account");

            entity.Property(e => e.LoaiQuyen)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MaNguoiDung)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("FK_account_users");
        });

        modelBuilder.Entity<BillDetailBan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bill_det__3213E83FCE0D1878");

            entity.ToTable("bill_detail_ban");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Chietkhau).HasColumnName("chietkhau");
            entity.Property(e => e.Giaban).HasColumnName("giaban");
            entity.Property(e => e.IdBillBan).HasColumnName("id_bill_ban");
            entity.Property(e => e.Masp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masp");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Tralai).HasColumnName("tralai");
        });

        modelBuilder.Entity<BillDetailNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bill_det__3213E83F721F88E5");

            entity.ToTable("bill_detail_nhap");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("created_at");
            entity.Property(e => e.DonVi)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("don_vi");
            entity.Property(e => e.IdBillNhap)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_bill_nhap");
            entity.Property(e => e.IdSp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_sp");
            entity.Property(e => e.Sl).HasColumnName("sl");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("date")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.IdBillNhapNavigation).WithMany(p => p.BillDetailNhaps)
                .HasForeignKey(d => d.IdBillNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bill_detail_nhap_bills_nhap");
        });

        modelBuilder.Entity<BillsBan>(entity =>
        {
            entity.HasKey(e => e.IdBillBan).HasName("PK__bills_ba__3213E83FE1F574F3");

            entity.ToTable("bills_ban");

            entity.Property(e => e.IdBillBan)
                .ValueGeneratedNever()
                .HasColumnName("id_bill_ban");
            entity.Property(e => e.IdKh)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_kh");
            entity.Property(e => e.Manguoidung)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("manguoidung");
            entity.Property(e => e.NgayBan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_ban");
            entity.Property(e => e.SoHoadon)
                .HasMaxLength(500)
                .HasColumnName("so_hoadon");
        });

        modelBuilder.Entity<BillsNhap>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bills_nh__3213E83F9227CC58");

            entity.ToTable("bills_nhap");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("date")
                .HasColumnName("created_at");
            entity.Property(e => e.DateOrder)
                .HasColumnType("date")
                .HasColumnName("date_order");
            entity.Property(e => e.IdNcc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_ncc");
            entity.Property(e => e.IdNhanvien)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_nhanvien");
            entity.Property(e => e.Note)
                .HasMaxLength(500)
                .HasColumnName("note");
            entity.Property(e => e.ThanhToan)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("thanh_toan");
            entity.Property(e => e.TongTien).HasColumnName("tong_tien");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("date")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChiTietDonHang>(entity =>
        {
            entity.HasKey(e => e.MaChiTietDonHang);

            entity.ToTable("ChiTietDonHang");

            entity.Property(e => e.MaSanPham)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Donhang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang);

            entity.ToTable("Donhang");

            entity.Property(e => e.MaKhachHang)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Ngaydat).HasColumnType("datetime");
            entity.Property(e => e.Trangthai).HasMaxLength(50);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__khach_ha__3213E83F9FBBB5BA");

            entity.ToTable("khach_hang");

            entity.Property(e => e.Id)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("dia_chi");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.Sdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("ten_kh");
        });

        modelBuilder.Entity<LoaiSp>(entity =>
        {
            entity.ToTable("loai_sp");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(100)
                .HasColumnName("tenloai");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("news");

            entity.Property(e => e.Content)
                .HasMaxLength(1000)
                .HasColumnName("content");
            entity.Property(e => e.IdNew)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_new");
            entity.Property(e => e.Image)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("nha_cung_cap");

            entity.Property(e => e.DiachiNcc)
                .HasMaxLength(200)
                .HasColumnName("diachi_ncc");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sdt");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(100)
                .HasColumnName("ten_ncc");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.ToTable("san_pham");

            entity.Property(e => e.Id)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.DonViTinh)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("don_vi_tinh");
            entity.Property(e => e.HanSudung)
                .HasColumnType("date")
                .HasColumnName("han_sudung");
            entity.Property(e => e.IdLoaiSp)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_loai_sp");
            entity.Property(e => e.IdNcc)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id_ncc");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.MotaSp)
                .HasMaxLength(250)
                .HasColumnName("mota_sp");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.NgaySanxuat)
                .HasColumnType("date")
                .HasColumnName("ngay_sanxuat");
            entity.Property(e => e.NgayThem)
                .HasColumnType("date")
                .HasColumnName("ngay_them");
            entity.Property(e => e.SoLuong).HasColumnName("so_luong");
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

            entity.HasOne(d => d.IdLoaiSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdLoaiSp)
                .HasConstraintName("FK_san_pham_loai_sp");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("full_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
