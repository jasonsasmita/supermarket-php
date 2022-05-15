using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Model
{
	public class Product
	{
		public int ProductID { get; set; }

		public string ProductName { get; set; }

        public int Price{ get; set; }

        public int Quantity { get; set; }
    }
}
