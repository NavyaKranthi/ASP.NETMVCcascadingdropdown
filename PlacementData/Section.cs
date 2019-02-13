namespace PlacementData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Section")]
    public partial class Section
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SectionId { get; set; }

        [StringLength(10)]
        public string SectionName { get; set; }

        public int? BranchId { get; set; }
    }
}
