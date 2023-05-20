namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class nha_cung_cap
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string ten_ncc { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(200)]
        public string diachi_ncc { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string email { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string sdt { get; set; }
    }
}
