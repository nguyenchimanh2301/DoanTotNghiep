namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_detail_nhap
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string id_bill_nhap { get; set; }

        [Required]
        [StringLength(20)]
        public string id_sp { get; set; }

        public int sl { get; set; }

        [Required]
        [StringLength(20)]
        public string don_vi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? created_at { get; set; }

        [Column(TypeName = "date")]
        public DateTime? updated_at { get; set; }

        public virtual bills_nhap bills_nhap { get; set; }
    }
}
