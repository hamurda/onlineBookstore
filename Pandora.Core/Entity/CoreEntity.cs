using Pandora.Core.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pandora.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        public CoreEntity()
        {
            CreatedDate = DateTime.Now;
            Status = Status.Active;

            CreatedIP = HttpContext.Current.Request.UserHostAddress;
        }


        public Guid ID { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedIP { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string UpdatedIP { get; set; }
    }
}
