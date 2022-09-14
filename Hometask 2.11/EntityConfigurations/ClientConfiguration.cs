using Hometask_2._11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._11.EntityConfigs
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            var peopleList = new List<Client>() {
                    new Client()
                    {
                        Id = 1,
                        FullName = "Jorja Smith",
                        Age = 25,
                        Gender = "Female"
                    },
                    new Client()
                    {
                        Id = 2,
                        FullName = "Adele Adkins",
                        Age = 33,
                        Gender = "Female"
                    },
                    new Client()
                    {
                        Id = 3,
                        FullName = "Phillip Anderson",
                        Age = 41,
                        Gender = "Male"
                    },
                };


            builder.HasData(peopleList);
        }
    }
}
