using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandora.UI.Models
{
    public class CartProduct
    {
        public Guid ID { get; set; }
        public decimal? Price { get; set; }
        public string Name { get; set; }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    _quantity = 0;
                }
            }
        }

        public string ImagePath { get; set; }
        public bool toBeRemoved { get; set; }
        public bool toWishlist { get; set; }
    }
}