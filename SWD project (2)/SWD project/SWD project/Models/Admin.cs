namespace SWD_project.Models
{
	public class Admin
	{
		public string Username = "AdminUser";
		public string Password = "AdminPass";
		public Boolean access=false;


		public void LogIn(string U, string P)
		{
			if (U == "AdminUser" && P == "AdminPass")
				access = true;
		}

		public void LogOut(string U, string P)
		{
				access = false;

		}

		public void AddProductToCatalog(Catalog catalog, Product product)
		{
			catalog.AddProduct(product);
		}

		public void RemoveProductFromCatalog(Catalog catalog, int productId)
		{
			catalog.RemoveProduct(productId);
		}

	}
}
