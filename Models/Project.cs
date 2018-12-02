using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab2_DIS.Models
{
    public class Project
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Project_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Project_Name { get; set; }

        public int Team { get; set; }

        [Required]
        [StringLength(50)]
        public string Project_Manager { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual Team Teams { get; set; }
    }
}
