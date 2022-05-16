namespace MultiCoreApp.MVC.DTOs
{
    public class ProductsWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
