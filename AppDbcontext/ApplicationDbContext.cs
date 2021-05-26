using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShort.Models;

namespace UrlShort.AppDbcontext
{
    public class ApplicationDbContext:DbContext
    {
        //  constructor to set up the data sets for the database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        // the DB context for the database , this uses the URLDetails Model
        public DbSet<UrlDetail> UrlDetails { get; set; }


    }


}

