namespace WebUI.ViewModels
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Product> Products { get; set; }
        public string UrlToRecipe { get; set; }
        public bool IsSnack { get; set; }
    }
}
