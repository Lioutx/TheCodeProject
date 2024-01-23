using Application.Products.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.ViewModels;

namespace WebUI.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public CreateModel(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        #region Model Properties 

        [BindProperty]
        public Product Product { get; set; }

        #endregion

        public async Task<IActionResult> OnPostAsync()
        {
            var productCreation = _mapper.Map<Domain.Entities.Product>(Product);

            bool success = await _mediator.Send(new CreateOrUpdateProductCommand() { Product = productCreation });
            //TODO: display error message on failure

            return Page();
        }
    }
}
