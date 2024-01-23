using Application.Products.Commands;
using Application.Products.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.ViewModels;

namespace WebUI.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public EditModel(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Model Properties

        [BindProperty]
        public Product Product { get; set; }

        #endregion

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _mediator.Send(new GetProductQuery() { ProductId = id});
            Product = _mapper.Map<Product>(product);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var productUpdate = _mapper.Map<Domain.Entities.Product>(Product);

            await _mediator.Send(new CreateOrUpdateProductCommand() { Product = productUpdate });

            return Page();
        }
    }
}
