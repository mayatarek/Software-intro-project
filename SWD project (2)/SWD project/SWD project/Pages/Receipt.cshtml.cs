using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD_project.Pages
{
    public class ReceiptModel : PageModel
    {
        public string OrderTime { get; set; }

        public void OnGet()
        {
            OrderTime = TempData["OrderTime"] as string;
        }
    }
}
