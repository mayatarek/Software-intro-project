using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace SWD_project.Pages
{
    public class ReceiptModel : PageModel
    {
        public string OrderTime { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Cname { get; set; }
        [BindProperty(SupportsGet = true)]
        public int CTotal { get; set; }
        [BindProperty(SupportsGet = true)]
        public int OrderID { get; set; }


        public void OnGet()
        {
            OrderTime = TempData["OrderTime"] as string;

            string connectionString = "Data Source=LAPTOP-8M8OHL36;Initial Catalog=Cafeteria;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            string query = "SELECT * INTO Cart2 FROM Cart;";
            SqlCommand cmd2 = new SqlCommand(query, conn);

            string queryRow1 = "Delete from Cart";
            SqlCommand cmd = new SqlCommand(queryRow1, conn);



            try
            {
                conn.Open();
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
            }

            finally
            {
                conn.Close();
            }

        }
    }
}

