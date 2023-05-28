namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bills_nhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bills_nhap()
        {
            bill_detail_nhap = new HashSet<bill_detail_nhap>();
        }

        [StringLength(20)]
        public string id { get; set; }

        [StringLength(20)]
        public string id_ncc { get; set; }

        [Required]
        [StringLength(20)]
        public string id_nhanvien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_order { get; set; }

        public double? tong_tien { get; set; }

        [StringLength(200)]
        public string thanh_toan { get; set; }

        [StringLength(500)]
        public string note { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill_detail_nhap> bill_detail_nhap { get; set; }
    }
}
