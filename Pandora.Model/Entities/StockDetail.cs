using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class StockDetail : CoreEntity
    {
        public virtual Book Book { get; set; }
        public Guid? BookID { get; set; }

        public virtual Dealer Dealer { get; set; }
        public Guid? DealerID { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Stock quantity cannot be lower than zero.")]
        public short? UnitsInStock { get; set; }

        [Range(0, short.MaxValue, ErrorMessage = "Order quantity cannot be lower than zero.")]
        public short? UnitsOnOrder { get; set; }

    }
}
