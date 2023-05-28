namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_detail_ban
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string id_bill_ban { get; set; }

        [Required]
        [StringLength(500)]
        public string listsanpham { get; set; }

        [Required]
        [StringLength(20)]
        public string id_kh { get; set; }

        public int? tongtien { get; set; }
    }
}
