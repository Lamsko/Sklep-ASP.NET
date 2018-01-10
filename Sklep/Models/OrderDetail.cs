﻿using System.ComponentModel.DataAnnotations;

namespace Sklep.Models
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }

		public int OrderId { get; set; }

		public string UserName { get; set; }

		public int ProductId { get; set; }

		public int Quantity { get; set; }

		public double? UnitPrice { get; set; }
	}
}