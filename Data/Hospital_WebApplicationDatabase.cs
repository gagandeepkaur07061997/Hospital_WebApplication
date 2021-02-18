using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hospital_WebApplication.Models;

namespace Hospital_WebApplication.Data
{
    public class Hospital_WebApplicationDatabase : DbContext
    {
        public Hospital_WebApplicationDatabase (DbContextOptions<Hospital_WebApplicationDatabase> options)
            : base(options)
        {
        }

        public DbSet<Hospital_WebApplication.Models.Companydetail> Companydetail { get; set; }

        public DbSet<Hospital_WebApplication.Models.Recieverdetail> Recieverdetail { get; set; }

        public DbSet<Hospital_WebApplication.Models.Senderdetail> Senderdetail { get; set; }

        public DbSet<Hospital_WebApplication.Models.Tracking> Tracking { get; set; }

        public DbSet<Hospital_WebApplication.Models.Parcel> Parcel { get; set; }
    }
}
