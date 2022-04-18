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
    public class CustomerSeed : IEntityTypeConfiguration<Customer>
    {
        private readonly Guid[] _guids;

        public CustomerSeed(Guid[] guids)
        {
            _guids = guids; 
        }
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer { Id = Guid.NewGuid(), Name = "Mehmet Aga",Address = "istanbul",City="ist",Email = "cgr@hotmail.com",IsDeleted = false,Phone = "555"},
                new Customer { Id = Guid.NewGuid(), Name = "Hasan Aga",Address = "ankara",City="ank",Email="feleket@hotmail.com",IsDeleted = false,Phone = "333"}
            );
        }
    }
}
