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
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly Guid[] _guids;

        public CategorySeed(Guid[] guids)
        {
            _guids = guids; 
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category { Id = _guids[0], Name = "Kalemler" },
                new Category { Id = _guids[1], Name = "Defterler" }
            );
        }
    }
}
