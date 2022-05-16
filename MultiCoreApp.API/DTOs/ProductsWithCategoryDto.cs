namespace MultiCoreApp.API.DTOs
{
    public class ProductsWithCategoryDto:ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
