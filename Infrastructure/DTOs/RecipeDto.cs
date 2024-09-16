namespace Infrastructure.DTOs
{
    public class RecipeDto 
    {
        public List<ProductDto> Products { get; set; }
        public string UrlToRecipe { get; set; }
        public bool IsSnack { get; set; }

    }
}