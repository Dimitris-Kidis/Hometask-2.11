using Hometask_2._11;
using Hometask_2._11.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


// Hometask 11
// 1. Seed Data ✅
// 2. Transactions: COMMIT & ROLLBACK ✅
// 3. Create queries, filters, projections, ordering. SQL Profiler ✅
// 4. Reproduce SELECT N+1 problem ✅
// 5. Create queries with all types of join (Inner, Left, Cross) ✅


namespace Hometask_2._11
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Transaction();
            //Operations();
            //NPlusOneProblem();
            //Joins();
        }

        public static void Transaction()
        {
            using (var context = new ScheduleDbContext())
            {
                using (IDbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Clients.Add(new Client() { FullName = "Peter Jackson", Age = 21, Gender = "Male"});
                        context.SaveChanges();

                        context.Schedules.Add(new Schedule() { ClientId = 3, Topic = "Family Time", Time = "20:30", Date = "01/01/2022" });
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Error occurred. " + ex.Message);
                    }
                }
            }
        }



        public static void NPlusOneProblem()
        {
            using var context = new ScheduleDbContext();

            foreach (var first in context.Clients)
            {
                foreach (var second in first.Schedules)
                {
                    Console.WriteLine($"Name: {first.FullName}, Topic: {second.Topic}");
                }
            }

            
        }

        public static void Operations()
        {
            using var context = new ScheduleDbContext();

            var clientMeetingsCount = context.Clients.Where(client => client.Schedules.Count > 2).OrderBy(x => x.Age).ToList();

            var specificTime = context.Schedules.Where(schedule => schedule.Time == "09:30").OrderByDescending(x => x.Topic).ToList();

            var specificDate = context.Schedules.Where(schedule => schedule.Date == "09/07/2022").Take(2).ToList();

            var clientsNameAge = context.Clients.Select(s => new { s.FullName, s.Age }).ToList();


        }

        public static void Joins()
        {
            var context = new ScheduleDbContext();

            // Inner
            var innerJoin = context.Clients.Join(context.Schedules,
                u => u.Id,
                c => c.ClientId,
                (u, c) => new { u.Id, u.FullName, c.Date, c.Time, c.Topic}
                );
            foreach (var item in innerJoin)
            {
                Console.WriteLine($"{item.Id}, {item.FullName}, {item.Date}, {item.Time}, {item.Topic}");
            }

            // Left
            var leftJoin = from clients in context.Clients
                           join schedules in context.Schedules on clients.Id equals schedules.ClientId into Info
                           from sch in Info.DefaultIfEmpty()
                           select new { clients.Id, clients.FullName, sch.Date, sch.Time, sch.Topic};
            Console.WriteLine("------------------------");
            foreach (var item in leftJoin)
            {
                Console.WriteLine($"{item.Id}, {item.FullName}, {item.Date}, {item.Time}, {item.Topic}");
            }

            // Cross
            var crossJoin = from first in context.Clients
                            from second in context.Schedules
                            select new { first.FullName, second.Topic };
            Console.WriteLine("------------------------");
            foreach (var item in crossJoin)
            {
                Console.WriteLine($"{item.FullName}, {item.Topic}");
            }
        }
    }
}