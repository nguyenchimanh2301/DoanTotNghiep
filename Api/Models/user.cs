namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(50)]
        public string full_name { get; set; }

        [Required]
        [StringLength(50)]
        public string users_name { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string phone { get; set; }
    }
}
