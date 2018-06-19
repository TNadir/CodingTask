using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Domen
{
    [Table("Sectors")]
    public class Sectors : AbstractEntity
    {
        public Sectors()
        {
            this.Childs = new HashSet<Sectors>();
            this.Applicants = new HashSet<Applicants>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Sectors Parent { get; set; }
        public virtual ICollection<Sectors> Childs { get; set; }

        public virtual ICollection<Applicants> Applicants { get; set; }

      
    }
}
