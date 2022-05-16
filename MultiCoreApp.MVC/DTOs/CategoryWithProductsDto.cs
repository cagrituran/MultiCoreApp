namespace MultiCoreApp.MVC.DTOs
{
    public class CategoryWithProductsDto:CategoryDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
