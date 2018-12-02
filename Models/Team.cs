using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab2_DIS.Models
{
    public class Team
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Team()
        //{
        //    Projects = new HashSet<Project>();
        //}

        [Key]
        public int Team_ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Team_Name { get; set; }

        public int Team_Leader { get; set; }

        public int Programmer1 { get; set; }

        public int Programmer2 { get; set; }

        public int Programmer3 { get; set; }

        //public virtual Programmer Programmers { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Project> Projects { get; set; }
    }
}
