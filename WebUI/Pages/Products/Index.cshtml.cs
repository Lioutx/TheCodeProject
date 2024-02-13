using Application.Products.Commands;
using Application.Products.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.ViewModels;

namespace WebUI.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public IndexModel(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Model Properties

        public List<Product> Products { get; set; }

        #endregion

        public async Task OnGetAsync()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            Products = _mapper.Map<List<Product>>(products).OrderBy(x => x.Name).ToList();
        }

        public async Task<ActionResult> OnGetDelete(int id)
        {
            await _mediator.Send(new DeleteProductCommand() { ProductId = id });

            return RedirectToAction("Index");
        }
    }
}
