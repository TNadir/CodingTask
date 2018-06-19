using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Domen
{
    [Table("Candidates")]
    public class Candidates : AbstractEntity
    {
        public Candidates()
        {
            this.Applicants = new HashSet<Applicants>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool AgreementStatus { get; set; }

        public virtual  ICollection<Applicants> Applicants { get; set; }
       
     
    }
}
