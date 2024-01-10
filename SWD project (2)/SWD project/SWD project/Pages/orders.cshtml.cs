using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace SWD_project.Pages
{
    public class ordersModel : PageModel
    {
        [BindProperty]
        public string OrderTime { get; set; }
        public List<OrderInfo> OrderItems { get; set; }
        public int ItemCount { get; set; }
        public int OrderTotal { get; set; }

        public class OrderInfo
        {
            public string productName { get; set; }
            public string productID { get; set; }
            public int productPrice { get; set; }
            public int OrderID { get; set; }


        }


        public void OnGet()
        {
            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();


                string checkTableQuery = "IF OBJECT_ID('dbo.cart2', 'U') IS NOT NULL SELECT 1 ELSE SELECT 0";
                SqlCommand checkTableCmd = new SqlCommand(checkTableQuery, connection);
                int tableExists = (int)checkTableCmd.ExecuteScalar();

                if (tableExists == 1)
                {

                    string query3 = "SELECT COUNT(*) FROM cart2";
                    SqlCommand Cmd3 = new SqlCommand(query3, connection);
                    ItemCount = (int)Cmd3.ExecuteScalar();

                    string query2 = "SELECT * FROM cart2";
                    SqlCommand infoCmd = new SqlCommand(query2, connection);

                    OrderItems = new List<OrderInfo>();

                    SqlDataReader reader = infoCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderItems.Add(new OrderInfo
                        {
                            productID = reader["ProductID"].ToString(),
                            productName = reader["ProductName"].ToString(),
                            productPrice = (int)reader["ProductPrice"],
                        });
                    }
                    reader.Close();
                }
                else
                {

                    ItemCount = 0;
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public IActionResult OnPost()
        {
            //TempData["OrderTime"] = OrderTime;
            return Page();
        }

        public void OnPostRemoveOrder()
        {
            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            string queryRow1 = "drop table Cart2";
            SqlCommand cmd = new SqlCommand(queryRow1, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
            }
        }


    }
}


