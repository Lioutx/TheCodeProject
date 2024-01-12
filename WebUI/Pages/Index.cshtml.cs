using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }

        public void OnGet()
        {
            Product item = Task.Run(async() => await _productService.GetProduct(2)).GetAwaiter().GetResult();
        }
    }
}
