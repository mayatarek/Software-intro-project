using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SWD_project.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Schema;
using System.Data.SqlClient;

namespace SWD_project.Pages
{
    public class CartModel : PageModel
    {
        public string CName { get; set; }
        public List<CartInfo> CartItems { get; set; }
        public int CartCount { get; set; }
        public int CartTotal { get; set; }

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

                string query3 = "SELECT COUNT(*) FROM cart";
                SqlCommand Cmd3 = new SqlCommand(query3, connection);
                CartCount = (int)Cmd3.ExecuteScalar();

                string query2 = "SELECT * FROM cart";
                SqlCommand infoCmd = new SqlCommand(query2, connection);

                CartItems = new List<CartInfo>();

                SqlDataReader reader = infoCmd.ExecuteReader();
                while (reader.Read())
                {
                    CartItems.Add(new CartInfo
                    {
                        productID = reader["ProductID"].ToString(),
                        productName = reader["ProductName"].ToString(),

                        productPrice = reader["ProductPrice"] is DBNull ? 0 : (int)reader["ProductPrice"]
                    });
                }
                reader.Close();


                string query4 = "SELECT SUM(ProductPrice) FROM cart";
                SqlCommand infoCmd1 = new SqlCommand(query4, connection);
                CartTotal = infoCmd1.ExecuteScalar() is DBNull ? 0 : (int)infoCmd1.ExecuteScalar();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public IActionResult OnPostPlaceOrder(string cartTotal, int ProductID, string ProductName, string ProductPrice)
        {
            Console.WriteLine(cartTotal);

            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string queryRow1 = "Insert into An_Order (TotalCost, ProductID, ProductPrice, ProductName) values (@total, @ProductID, @ProductPrice, @ProductName)";

            SqlCommand cmd = new SqlCommand(queryRow1, conn);

            cmd.Parameters.Add("@total", SqlDbType.Int).Value = cartTotal;
            cmd.Parameters.Add("@ProductID", SqlDbType.NVarChar, 9).Value = ProductID;
            cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 20).Value = ProductName;
            cmd.Parameters.Add("@ProductPrice", SqlDbType.NVarChar, 15).Value = ProductPrice;
            CName = Request.Form["customerName"];

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

            return RedirectToPage("/Receipt", new { CTotal = cartTotal, cname = CName });
        }
        //else
        //{

        //    return RedirectToPage("/Cart");
        //}
    }

}
