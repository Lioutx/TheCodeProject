using Application.Products.Queries;
using Domain.Entities;
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

		public List<Product> Products { get; set; }

		public int Id { get; set; }
		public string Name { get; set; }
        
        #endregion

		public async Task OnGetAsync()
		{
            Products = await _mediator.Send(new GetProductsQuery());
		}
    }
}
