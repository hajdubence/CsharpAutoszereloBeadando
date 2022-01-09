using System.Text.Json;
using AutoSzerelo_Common.Models;
using AutoSzerelo_Server.Properties;

namespace AutoSzerelo_Server.Repositories
{
    public static class RepairRepository
    {

        public static IEnumerable<Repair> GetRepairs()
        {
            using(var database = new RepairContext())
            {
                var repairs = database.Repairs.OrderBy(c => c.DateOfRecording).ToList();

                return repairs;
            }
        }

        public static Repair GetRepair(long id)
        {
            using (var database = new RepairContext())
            {
                var repair = database.Repairs.Where(c => c.Id == id).FirstOrDefault();

                return repair;
            }
        }

        public static void AddRepair(Repair repair)
        {
            using (var database = new RepairContext())
            {
                database.Repairs.Add(repair);

                database.SaveChanges();
            }
        }

        public static void UpdateRepair(Repair repair)
        {
            using (var database = new RepairContext())
            {
                database.Repairs.Update(repair);

                database.SaveChanges();


            }
        }

        public static void DeleteRepair(Repair repair)
        {
            using (var database = new RepairContext())
            {
                database.Repairs.Remove(repair);

                database.SaveChanges();
            }
        }
    }
}
