using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccesAzureStorageWebApp.Models;
using Microsoft.Graph;
using Microsoft.Extensions.Logging;
using System.IO;
using System;
using Microsoft.Identity.Web;

namespace AccesAzureStorageWebApp.Pages.Storage_MSI
{
    public class IndexModel : PageModel
    {
        private readonly AccesAzureStorageWebApp.Data.CommentsContext _context;
        public IndexModel(AccesAzureStorageWebApp.Data.CommentsContext context)
        {
            _context = context;
        }

        public IList<Comment> Comments { get; set; }
        public async Task OnGetAsync()
        {
            Comments = await _context.GetComments();

        }
    }
}

