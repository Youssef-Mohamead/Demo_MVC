using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Models
{
    public class BaseEntity // 3bara 3n class bgm3 feeh el7agat elmo4traka
    {
        public int Id { get; set; } // PK
        public int CreatedBy { get; set; } // User Id
        public DateTime? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User Id
        public DateTime? LastModifiedOn { get; set; }
        public bool ISDeleted { get; set; } // Soft Delete

    }
}
