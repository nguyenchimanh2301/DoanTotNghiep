namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class san_pham
    {
        [StringLength(20)]
        public string id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(20)]
        public string id_loai_sp { get; set; }

        [Required]
        [StringLength(20)]
        public string id_ncc { get; set; }

        [StringLength(250)]
        public string mota_sp { get; set; }

        public int? unit_price { get; set; }

        public int so_luong { get; set; }

        [StringLength(255)]
        public string image { get; set; }

        [StringLength(255)]
        public string don_vi_tinh { get; set; }

        public virtual loai_sp loai_sp { get; set; }
    }
}
