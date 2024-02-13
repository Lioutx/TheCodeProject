using Application.Recipes.Queries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.ViewModels;

namespace WebUI.Pages.Recipes
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

        public List<Recipe> Recipes { get; set; }

        #endregion

        public async Task OnGetAsync()
        {
            var products = await _mediator.Send(new GetRecipesQuery());
            Recipes = _mapper.Map<List<Recipe>>(products).OrderBy(x => x.Title).ToList();
        }
    }
}
