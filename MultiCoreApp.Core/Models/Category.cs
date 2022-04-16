using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCoreApp.Core.Models
{
    public class Category
    {
        public Guid Id { get; set; } /*= Guid.NewGuid();*/
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Product> Products { get; set; }  
    }
}
