using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizSoft.SerilogSample.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string StatusMessage { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Page Index called");

            int j = 10;
            try
            {
                _logger.LogWarning("Entering in a dangerous loop...");
                for (int i = 1; i <= 10; i++)
                {
                    _logger.LogInformation("Counter is {LoopCounter}", i);
                    var k = j / (5 - i);    //exception when i = 5
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ACME Index Module");
                StatusMessage = ex.Message;
            }
            
        }
    }
}
