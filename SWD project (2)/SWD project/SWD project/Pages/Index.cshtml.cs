using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Numerics;
using System.Xml.Linq;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using SWD_project.Models;
using System.Linq;
using System.Data;




namespace SWD_project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<ProductInfo> Products { get; set; }
        public int ProductCount { get; set; }

        //Cart
        public string productName { get; set; }
        public string productID { get; set; }
        public int productPrice { get; set; }
        public int CartID { get; set; }


        public class ProductInfo
        {
            //Products
            public string ProductName { get; set; }
            public string ProductID { get; set; }
            public int ProductPrice { get; set; }

        }


        public List<CartInfo> CartItems { get; set; }
        public int CartCount { get; set; }

        public class CartInfo
        {
            public string productName { get; set; }
            public string productID { get; set; }
            public int productPrice { get; set; }
            public int CartID { get; set; }

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





        public IActionResult OnPostAdd(string ID, string ProductN, string ProductPrice)
        {
            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string queryRow1 = "Insert into Cart (CartID, ProductID, ProductName, ProductPrice) values (1, @ID, @ProductN, @ProductPrice)";
            SqlCommand cmd = new SqlCommand(queryRow1, conn);

            cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 20).Value = ID;
            cmd.Parameters.Add("@ProductN", SqlDbType.NVarChar, 30).Value = ProductN;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.NVarChar, 20).Value = ProductPrice;


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();


            }
            finally
            {
                conn.Close();

            }
            return RedirectToPage();
        }



        public IActionResult OnPostCart()
        {
            return RedirectToPage("/Cart");
        }
