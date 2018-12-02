using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab2_DIS.Models
{
    public class Programmer
    {
        [Key]
        public int Programmer_ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Programmer_Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Position { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = CompanyContext.FieldLenErrMsg)]
        public string Main_Skill { get; set; }
    }
}
