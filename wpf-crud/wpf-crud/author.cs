namespace wpf_crud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class author
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public author()
        {
            titleauthors = new HashSet<titleauthor>();
        }

        [Key]
        [StringLength(11)]
        public string au_id { get; set; }

        [Required]
        [StringLength(40)]
        public string au_lname { get; set; }

        [Required]
        [StringLength(20)]
        public string au_fname { get; set; }

        [Required]
        [StringLength(12)]
        public string phone { get; set; }

        [StringLength(40)]
        public string address { get; set; }

        [StringLength(20)]
        public string city { get; set; }

        [StringLength(2)]
        public string state { get; set; }

        [StringLength(5)]
        public string zip { get; set; }

        public bool contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<titleauthor> titleauthors { get; set; }

        public string FullName => au_fname + ' ' + au_lname;

        public override string ToString() => au_id;
    }
}
