using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab2_DIS.Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }

        [Required]
        [StringLength(50)] //, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Company { get; set; }

        [Required]
        [StringLength(50)] //, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Representative { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Phone { get; set; }

        [Column("e-mail")]
        [Required]
        [StringLength(50)] //, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string e_mail { get; set; }

        public int Project { get; set; }

        public virtual Project Projects { get; set; }
    }
}
