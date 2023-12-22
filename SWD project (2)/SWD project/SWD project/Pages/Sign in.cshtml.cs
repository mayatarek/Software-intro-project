using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SWD_project.Pages
{
    public class Sign_inModel : PageModel
    {
        [BindProperty]
        public string User { get; set; }

        [BindProperty]
        public string Pass { get; set; }

        public bool ShowInvalidCredentialsMessage { get; set; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (User == "AdminUser" && Pass == "AdminPass")
            {
                return RedirectToPage("/Admin");
            }
            else
            {
                ShowInvalidCredentialsMessage = true;
                return Page();
            }
        }
    }
}
