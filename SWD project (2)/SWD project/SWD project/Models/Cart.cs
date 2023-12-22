namespace SWD_project.Models
{
	public class Cart
	{
		public float CartCost { get; set; }
		List<Product> ProductsInCart = new List<Product>();

		public void GetCartCost()
		{
			CartCost = 0;
			foreach (Product p in ProductsInCart)
			{
				CartCost = CartCost + p.Price;

			}
		}


		public void AddToCart(Product product)
		{
			ProductsInCart.Add(product);
		}

		public void RemoveFromCart(Product product)
		{
				ProductsInCart.Remove(product);
			
		}

		public void ViewCart(Product product)
		{

			foreach (Product p in ProductsInCart)
			{
				Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}");
			}
			
		}

		public void ConfirmOrder()
		{
			if (ProductsInCart.Count > 0)
			{
				Order S = new Order();
				foreach (Product p in ProductsInCart)
				{
					S.OrderedProducts.Add(p);
				}
				S.TotalCost=CartCost;
			}
		}



	}
}
