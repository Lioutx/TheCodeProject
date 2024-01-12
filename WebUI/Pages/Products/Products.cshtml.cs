using Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages.Products
{
	public class ProductsModel : PageModel
    {
        private readonly ISender _mediator;

		public ProductsModel(ISender mediator)
		{
			_mediator = mediator;
		}


		#region Model Properties

		public int Id { get; set; }
		public string Name { get; set; }
        
        #endregion

		public async void OnGet()
		{
            var result = await _mediator.Send(new GetProductsQuery());
		}

        public async Task<IActionResult> OnGetDataAsync()
        {
			var result = await _mediator.Send(new GetProductsQuery());
			return new JsonResult(result);
        }
    }
}
