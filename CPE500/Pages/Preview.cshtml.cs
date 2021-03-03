using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPE500.Pages
{
    public class PreviewModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string FilePath { get; set; }
        
        public string FullFilePath { get; set; }

        public void OnGet()
        {
            string filePathUrl = FilePath.Replace("\\", "/");
            filePathUrl = Uri.EscapeDataString($"{Request.Scheme}s://{Request.Host}{Request.PathBase}/{filePathUrl}");
            FullFilePath = filePathUrl;
        }
    }
}
