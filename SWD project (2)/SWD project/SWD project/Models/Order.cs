namespace SWD_project.Models
{
	public class Order
	{
		public int OrderID { get; set; }
		public float TotalCost { get; set; }
		public int TimeLeft { get; set; }

		public List<Product> OrderedProducts = new List<Product>();

		public void RemoveOrder()
		{
			foreach (Product p in OrderedProducts)
			{
				OrderedProducts.Remove(p);
			}

		}

	}
}
