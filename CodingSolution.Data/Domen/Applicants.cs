using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Domen
{
    [Table("Applicants")]
    public class Applicants : AuditEntity
    {
        [Required]
        public int SectorId { get; set; }

        [Required]
        public int CandidateId { get; set; }

        public virtual Sectors Sector { get; set; }

        public virtual Candidates Candidate { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }
    }
}
