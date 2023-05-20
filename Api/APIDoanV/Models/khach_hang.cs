namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class khach_hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khach_hang()
        {
            bills_ban = new HashSet<bills_ban>();
        }

        [StringLength(20)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string ten_kh { get; set; }

        [Required]
        [StringLength(255)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string dia_chi { get; set; }

        [Required]
        [StringLength(20)]
        public string sdt { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bills_ban> bills_ban { get; set; }
    }
}
