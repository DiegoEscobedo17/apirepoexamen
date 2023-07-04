namespace ApiExamenesFinal2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Examenes
    {
        public int id { get; set; }

        [StringLength(50)]
        public string texto { get; set; }

        [StringLength(50)]
        public string procentaje { get; set; }

        [StringLength(50)]
        public string curso { get; set; }

        [StringLength(50)]
        public string precio { get; set; }

        public bool? imagen { get; set; }
    }
}
