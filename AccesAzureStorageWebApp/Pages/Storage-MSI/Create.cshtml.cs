using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccesAzureStorageWebApp.Models;

namespace AccesAzureStorageWebApp.Pages.Storage_MSI
{
    public class CreateModel : PageModel
    {
        private readonly AccesAzureStorageWebApp.Data.CommentsContext _context;
        public CreateModel(AccesAzureStorageWebApp.Data.CommentsContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Comment Comment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.CreateComment(Comment);

            return RedirectToPage("./Index");
        }
    }
}
