namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bills_ban
    {
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(20)]
        public string id_kh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngay_dat { get; set; }

        public double? tong_tien { get; set; }

        [Required]
        [StringLength(200)]
        public string trangthai { get; set; }

        [StringLength(500)]
        public string ghichu { get; set; }

        [Required]
        [StringLength(200)]
        public string ten_kh { get; set; }

        public virtual khach_hang khach_hang { get; set; }
    }
}
