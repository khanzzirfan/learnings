using System;

namespace recyclerviewlistner
{
	public class Vegetable
	{
		public int VegeID { get; set; }
		public string Name { get; set; }
		public int	Quantity { get; set; }
		public bool AddToOrder { get; set; }
		public int Price { get; set; }
		public int ImageId { get; set; }
	
		public Vegetable (int vegeId, string vegeName, int quantity, bool order, int price, int imageID)
		{
			this.VegeID = vegeId;
			this.Name = vegeName;
			this.Quantity = quantity;
			this.AddToOrder = order;
			this.Price = price;
			this.ImageId = imageID;
		}
	}

}

