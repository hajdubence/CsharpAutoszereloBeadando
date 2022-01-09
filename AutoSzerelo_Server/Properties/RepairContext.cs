using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using AutoSzerelo_Common.Models;

namespace AutoSzerelo_Server.Properties
{
    public class RepairContext : DbContext
    {

        public DbSet<Repair> Repairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(
                "Data Source=(localdb)\\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }
    }
}
