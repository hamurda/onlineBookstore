using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class OrderDetail : CoreEntity
    {
        public Guid? OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Guid? BookID { get; set; }
        public virtual Book Book { get; set; }

        public decimal? UnitPrice { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Order quantity cannot be lower than zero.")]
        public short? Quantity { get; set; }
        public float? Discount { get; set; }
        public bool IsReturn { get; set; }       
    }
}
