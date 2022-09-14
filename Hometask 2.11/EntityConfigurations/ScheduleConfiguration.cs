using Hometask_2._11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_2._11.EntityConfigurations
{
    internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            var scheduleList = new List<Schedule>() {
                    new Schedule { Id = 9, ClientId = 1, Topic = "Work Meeting", Time = "09:30", Date = "09/07/2022"},
                    new Schedule { Id = 10, ClientId = 1, Topic = "Talking", Time = "12:10", Date = "09/07/2022"},
                    new Schedule { Id = 11, ClientId = 1, Topic = "English Practice", Time = "16:00", Date = "09/07/2022"},
                    new Schedule { Id = 12, ClientId = 1, Topic = "Family Call", Time = "20:00", Date = "09/07/2022"},
                    new Schedule { Id = 13, ClientId = 2, Topic = "Rehearsal", Time = "09:30", Date = "10/01/2022"},
                    new Schedule { Id = 14, ClientId = 2, Time = "12:10", Date = "09/07/2022"},
                    new Schedule { Id = 15, ClientId = 2, Topic = "Relax", Time = "21:00", Date = "01/01/2022"},
                    new Schedule { Id = 16, ClientId = 3, Topic = "Lecture Time", Time = "13:50", Date = "02/04/2022"},
                    new Schedule { Id = 17, ClientId = 3, Topic = "Vacation", Time = "09:00", Date = "04/09/2022"}
                };


            builder.HasData(scheduleList);
        }
    }
}
