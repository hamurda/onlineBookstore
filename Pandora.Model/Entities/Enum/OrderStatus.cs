using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities.Enum
{
    public enum OrderStatus
    {
        Pending=1,
        Processing,
        Shipped,
        Delivered,
        Returned,
        Cancelled
    }
}
