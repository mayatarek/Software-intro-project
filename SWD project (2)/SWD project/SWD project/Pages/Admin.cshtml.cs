using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD_project.Models;
using static SWD_project.Pages.IndexModel;
using System.Data;
using System.Data.SqlClient;

namespace SWD_project.Pages
{

    public class Admin_pageModel : PageModel
    {
        [BindProperty]
        public string ProductName { get; set; }
        [BindProperty]
        public string ProductID { get; set; }
        [BindProperty]
        public int ProductPrice { get; set; }
        [BindProperty]

        public string productName { get; set; }
        [BindProperty]
        public int productID { get; set; }
        [BindProperty]
        public int productPrice { get; set; }
        public List<ProductInfo> Products { get; set; }
        public int ProductCount { get; set; }

        public class ProductInfo
        {
            public string ProductName { get; set; }
            public string ProductID { get; set; }
            public int ProductPrice { get; set; }
        }

        public void OnGet()
        {

            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();

                string query1 = "SELECT COUNT(*) FROM Product";
                SqlCommand CountCmd = new SqlCommand(query1, connection);
                ProductCount = (int)CountCmd.ExecuteScalar();

                string query2 = "SELECT * FROM Product";
                SqlCommand infoCmd = new SqlCommand(query2, connection);

                Products = new List<ProductInfo>();

                SqlDataReader reader = infoCmd.ExecuteReader();
                while (reader.Read())
                {
                    Products.Add(new ProductInfo
                    {
                        ProductID = reader["ProductID"].ToString(),
                        ProductName = reader["ProductName"].ToString(),
                        ProductPrice = (int)reader["ProductPrice"]
                    });
                }
                reader.Close();
            }

            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public IActionResult OnPostRemoveProduct(int productId)
        {
            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string queryClient = $"DELETE FROM Product WHERE ProductID = {productId}";
                using (SqlCommand ClientCmd = new SqlCommand(queryClient, conn))
                {
                    ClientCmd.ExecuteNonQuery();
                }
            }
            return RedirectToPage();
        }

        public IActionResult OnPostAddProduct(IFormFile fileToUpload)
        {
            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string query = "INSERT INTO Product VALUES (@ProductID, @ProductName, @ProductPrice)";
            SqlCommand Cmd = new SqlCommand(query, conn);

            Cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
            Cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 50).Value = productName;
            Cmd.Parameters.Add("@ProductPrice", SqlDbType.Int).Value = productPrice;

            if (fileToUpload != null && fileToUpload.Length > 0)
            {
                // Specify the folder where you want to save the files
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // Ensure the folder exists, create it if necessary
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // Save the file to the server
                var filePath = Path.Combine(uploadFolder, fileToUpload.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    fileToUpload.CopyTo(stream);
                }

                // Optionally, you can do something with the file path here
                // For example, you might want to store it in ViewData for display on the page
                ViewData["FilePath"] = filePath;
            }
            try
            {
                conn.Open();
                Cmd.ExecuteNonQuery();

            }
            finally
            {

                conn.Close();

            }
            return RedirectToPage();
        }
    }

}
