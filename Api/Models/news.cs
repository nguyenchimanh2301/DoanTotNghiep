namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class news
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string id_new { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(200)]
        public string title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1000)]
        public string content { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string image { get; set; }
    }
}
