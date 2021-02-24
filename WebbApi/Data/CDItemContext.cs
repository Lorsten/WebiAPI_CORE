using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebbApi.Models;

namespace WebbApi.Data
{
    public class CDItemContext : DbContext
    {
        public CDItemContext(DbContextOptions<CDItemContext> options)
            : base(options)
        {

        }
        public DbSet<CDItem> CDS { get; set; }

    }
}
