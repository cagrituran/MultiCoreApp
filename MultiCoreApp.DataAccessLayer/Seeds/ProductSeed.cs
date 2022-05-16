using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCoreApp.Core.Models;

namespace MultiCoreApp.DataAccessLayer.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly Guid[] _guids;

        public ProductSeed(Guid[] guids)
        {
            _guids = guids; 
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Dolma Kalem", Price = 122.53m, CategoryId = _guids[0] },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Tukenmez Kalem", Price = 18.06m, CategoryId = _guids[0] },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Kursun Kalem", Price = 62.13m, CategoryId = _guids[0] },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Cizgili Defter", Price = 122.53m, CategoryId = _guids[1] },
                new Product { Id = Guid.NewGuid(), Stock = 100, Name = "Kareli Defter", Price = 18.06m, CategoryId = _guids[1] },
                new Product { Id = Guid.NewGuid(), Name = "Dumduz Defter", Price = 62.13m, CategoryId = _guids[1] }
            );
        }
    }
}
