using System.Collections.Specialized;

namespace SWD_project.Models
{
	public class Catalog
	{
		List<Product> productList = new List<Product>();
		public void AddProduct(Product product)
		{
			productList.Add(product);
		}

		public void RemoveProduct(int productID)
		{
			Product product = null;
			foreach (Product p in productList)
			{
				if (p.ProductID == productID)
				{
					product = p;
					break; 
				}
			}
			if (product != null)
			{
				productList.Remove(product);
			}
		}

		public List<Product> PrintProductList()
		{
			return productList;
		}

		public void DisplayProductDetails(Product product)
		{
			Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.Name}, Price: {product.Price}");
		}


	}
}
