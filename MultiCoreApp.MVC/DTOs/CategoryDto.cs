using System.ComponentModel.DataAnnotations;

namespace MultiCoreApp.MVC.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; } /*= Guid.NewGuid();*/
        [Required(ErrorMessage = "{0} alani zorunludur.")]
        public string Name { get; set; }
    }
}
