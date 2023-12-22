using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SWD_project.Pages
{
    public class ordersModel : PageModel
    {
        [BindProperty]
        public string OrderTime { get; set; }

        public IActionResult OnPost()
        {
            TempData["OrderTime"] = OrderTime;
            return Page();
        }


    }
}

