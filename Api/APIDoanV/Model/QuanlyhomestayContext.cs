using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APIDoanV.Model;

public partial class QuanlyhomestayContext : DbContext
{
    public QuanlyhomestayContext()
    {
    }

    public QuanlyhomestayContext(DbContextOptions<QuanlyhomestayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Baiviet> Baiviets { get; set; }

    public virtual DbSet<ChiTietHoaDonBan> ChiTietHoaDonBans { get; set; }

    public virtual DbSet<ChiTietHoaDonNhap> ChiTietHoaDonNhaps { get; set; }

    public virtual DbSet<ChitietDatPhong> ChitietDatPhongs { get; set; }

    public virtual DbSet<DatPhong> DatPhongs { get; set; }

    public virtual DbSet<DonViTinh> DonViTinhs { get; set; }

    public virtual DbSet<HoaDonBanHang> HoaDonBanHangs { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Lapdat> Lapdats { get; set; }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<LoaiThietBi> LoaiThietBis { get; set; }

    public virtual DbSet<MatHang> MatHangs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<Nhaptb> Nhaptbs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<ThietBi> ThietBis { get; set; }

    public virtual DbSet<TinhLuong> TinhLuongs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-LLHPT87U\\SQLEXPRESS;Database=QUANLYHOMESTAY;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan);

            entity.ToTable("account");

            entity.Property(e => e.Idkh).HasColumnName("idkh");
            entity.Property(e => e.LoaiQuyen)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MatKhau)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NgayBatDau).HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.TaiKhoan)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdkhNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Idkh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_account_khach_hang");
        });

        modelBuilder.Entity<Baiviet>(entity =>
        {
            entity.HasKey(e => e.Idbaiviet);

            entity.ToTable("Baiviet");

            entity.Property(e => e.Idbaiviet).HasColumnName("idbaiviet");
            entity.Property(e => e.Anh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Iduser).HasColumnName("iduser");
            entity.Property(e => e.Ngaydangbai)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Noidung).HasMaxLength(1000);
            entity.Property(e => e.Tieude).HasMaxLength(100);
        });

        modelBuilder.Entity<ChiTietHoaDonBan>(entity =>
        {
            entity.HasKey(e => new { e.IdhoaDon, e.IdmatHang });

            entity.ToTable("ChiTietHoaDonBan");

            entity.Property(e => e.IdhoaDon).HasColumnName("IDHoaDon");
            entity.Property(e => e.IdmatHang).HasColumnName("IDMatHang");
            entity.Property(e => e.Sl).HasColumnName("SL");

            entity.HasOne(d => d.IdhoaDonNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.IdhoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDonBan_HoaDonBanHang");

            entity.HasOne(d => d.IdmatHangNavigation).WithMany(p => p.ChiTietHoaDonBans)
                .HasForeignKey(d => d.IdmatHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDonBan_MatHang");
        });

        modelBuilder.Entity<ChiTietHoaDonNhap>(entity =>
        {
            entity.HasKey(e => new { e.IdhoaDon, e.IdmatHang });

            entity.ToTable("ChiTietHoaDonNhap");

            entity.Property(e => e.IdhoaDon).HasColumnName("IDHoaDon");
            entity.Property(e => e.IdmatHang).HasColumnName("IDMatHang");

            entity.HasOne(d => d.IdhoaDonNavigation).WithMany(p => p.ChiTietHoaDonNhaps)
                .HasForeignKey(d => d.IdhoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDonNhap_HoaDonNhap");

            entity.HasOne(d => d.IdmatHangNavigation).WithMany(p => p.ChiTietHoaDonNhaps)
                .HasForeignKey(d => d.IdmatHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHoaDonNhap_MatHang");
        });

        modelBuilder.Entity<ChitietDatPhong>(entity =>
        {
            entity.HasKey(e => new { e.Idp, e.Iddondat });

            entity.ToTable("ChitietDatPhong");

            entity.Property(e => e.Idp).HasColumnName("idp");
            entity.Property(e => e.Iddondat).HasColumnName("iddondat");
            entity.Property(e => e.Dongia).HasColumnName("dongia");
            entity.Property(e => e.Thanhtien).HasColumnName("thanhtien");
            entity.Property(e => e.Tongthoigiandat).HasColumnName("tongthoigiandat");

            entity.HasOne(d => d.IdpNavigation).WithMany(p => p.ChitietDatPhongs)
                .HasForeignKey(d => d.Idp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChitietDatPhong_Phong");
        });

        modelBuilder.Entity<DatPhong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DatPhong_1");

            entity.ToTable("DatPhong");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idkh).HasColumnName("idkh");
            entity.Property(e => e.Ngaydat).HasColumnType("datetime");
            entity.Property(e => e.Ngaytra).HasColumnType("datetime");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(50)
                .HasColumnName("tenkh");
            entity.Property(e => e.Thanhtien)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.IdkhNavigation).WithMany(p => p.DatPhongs)
                .HasForeignKey(d => d.Idkh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DatPhong_khach_hang1");
        });

        modelBuilder.Entity<DonViTinh>(entity =>
        {
            entity.ToTable("DonViTinh");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.TenDvt)
                .HasMaxLength(30)
                .HasColumnName("TenDVT");
        });

        modelBuilder.Entity<HoaDonBanHang>(entity =>
        {
            entity.HasKey(e => e.IdhoaDon);

            entity.ToTable("HoaDonBanHang");

            entity.Property(e => e.IdhoaDon).HasColumnName("IDHoaDon");
            entity.Property(e => e.Idphong).HasColumnName("IDPhong");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NguoiBan)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Nguoitao)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ThoiGianBdau)
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianBDau");
            entity.Property(e => e.ThoiGianKthuc)
                .HasColumnType("datetime")
                .HasColumnName("ThoiGianKThuc");

            entity.HasOne(d => d.IdphongNavigation).WithMany(p => p.HoaDonBanHangs)
                .HasForeignKey(d => d.Idphong)
                .HasConstraintName("FK_HoaDonBanHang_Phong");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdnhaCc).HasColumnName("IDNhaCC");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayNhap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.NhanVienNhap)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdnhaCcNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.IdnhaCc)
                .HasConstraintName("FK_HoaDonNhap_NhaCungCap");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.ToTable("khach_hang");

            entity.Property(e => e.Id).HasColumnName("id");
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

        modelBuilder.Entity<Lapdat>(entity =>
        {
            entity.ToTable("Lapdat");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idphong).HasColumnName("IDPhong");
            entity.Property(e => e.IdthietBi).HasColumnName("IDThietBi");
            entity.Property(e => e.NgayLapdat).HasColumnType("datetime");
            entity.Property(e => e.Sllapdat).HasColumnName("SLLapdat");

            entity.HasOne(d => d.IdphongNavigation).WithMany(p => p.Lapdats)
                .HasForeignKey(d => d.Idphong)
                .HasConstraintName("FK_Lapdat_Phong");

            entity.HasOne(d => d.IdthietBiNavigation).WithMany(p => p.Lapdats)
                .HasForeignKey(d => d.IdthietBi)
                .HasConstraintName("FK_Lapdat_ThietBi");
        });

        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.ToTable("LoaiPhong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NgayCapNhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTao).HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.TenLoaiPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<LoaiThietBi>(entity =>
        {
            entity.ToTable("LoaiThietBi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mota).HasMaxLength(50);
            entity.Property(e => e.TenLoaiTb)
                .HasMaxLength(50)
                .HasColumnName("TenLoaiTB");
        });

        modelBuilder.Entity<MatHang>(entity =>
        {
            entity.ToTable("MatHang");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Dvt).HasColumnName("DVT");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Ngaytao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.Nguoitao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.TenMatHang).HasMaxLength(50);

            entity.HasOne(d => d.DvtNavigation).WithMany(p => p.MatHangs)
                .HasForeignKey(d => d.Dvt)
                .HasConstraintName("FK_MatHang_DonViTinh");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.ToTable("NhaCungCap");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(50)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.Username);

            entity.ToTable("NhanVien");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ChucVu)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DiaChi).HasMaxLength(150);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HoVaTen).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Nhaptb>(entity =>
        {
            entity.HasKey(e => e.Idhd);

            entity.ToTable("Nhaptb");

            entity.Property(e => e.Idhd)
                .ValueGeneratedNever()
                .HasColumnName("IDHD");
            entity.Property(e => e.Idthietbi)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("IDThietbi");

            entity.HasOne(d => d.IdhdNavigation).WithOne(p => p.Nhaptb)
                .HasForeignKey<Nhaptb>(d => d.Idhd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nhaptb_HoaDonNhap");
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.ToTable("Phong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Anh)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.DiaChi)
                .HasMaxLength(50)
                .HasColumnName("DIaChi");
            entity.Property(e => e.IdloaiPhong).HasColumnName("IDLoaiPhong");
            entity.Property(e => e.Mota)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayThem)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NguoiCapNhat)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.NguoiTao)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('admin')");
            entity.Property(e => e.TenPhong).HasMaxLength(50);

            entity.HasOne(d => d.IdloaiPhongNavigation).WithMany(p => p.Phongs)
                .HasForeignKey(d => d.IdloaiPhong)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        modelBuilder.Entity<ThietBi>(entity =>
        {
            entity.ToTable("ThietBi");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdloaiTb).HasColumnName("IDLoaiTB");
            entity.Property(e => e.Kichthuoc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mausac).HasMaxLength(50);
            entity.Property(e => e.TenThietBi).HasMaxLength(50);

            entity.HasOne(d => d.IdloaiTbNavigation).WithMany(p => p.ThietBis)
                .HasForeignKey(d => d.IdloaiTb)
                .HasConstraintName("FK_ThietBi_LoaiThietBi");
        });

        modelBuilder.Entity<TinhLuong>(entity =>
        {
            entity.ToTable("TinhLuong");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idusername)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("IDusername");
            entity.Property(e => e.LuongCb).HasColumnName("LuongCB");
            entity.Property(e => e.Ngaybatdau)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Songaynghi).HasColumnName("songaynghi");

            entity.HasOne(d => d.IdusernameNavigation).WithMany(p => p.TinhLuongs)
                .HasForeignKey(d => d.Idusername)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TinhLuong_NhanVien");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("users");

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
            entity.Property(e => e.Id)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("id");
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
