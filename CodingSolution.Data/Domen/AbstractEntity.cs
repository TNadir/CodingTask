using CodingSolution.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Domen
{
    public abstract class AbstractEntity : AuditEntity, IBaseEntity
    {
        public  DateTime CreateDate { get; set; }
        public   int Id { get; set; }
    }
}
