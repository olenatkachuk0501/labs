using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab2_DIS.Models;

namespace Lab2_DIS.Models
{
    public class CompanyContext : DbContext
    {
        public const string FieldLenErrMsg = "Field length should't be greater than 50 characters";

        public CompanyContext (DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<Lab2_DIS.Models.Programmer> Programmers { get; set; }

        public DbSet<Lab2_DIS.Models.Team> Teams { get; set; }
    }
}
