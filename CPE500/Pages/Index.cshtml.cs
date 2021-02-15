using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CPE500.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _webHost;

        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment webHost)
        {
            _logger = logger;
            _webHost = webHost;
        }

        public List<string> AssetDirectories { get; set; }

        public string PathSeparator { get; set; }

        public void OnGet()
        {
            string assetPath = Path.Combine(_webHost.WebRootPath, "Assets");
            AssetDirectories = Directory.EnumerateDirectories(assetPath).OrderBy(x => x).ToList();
            PathSeparator = RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "/" : "\\";
        }
    }
}
