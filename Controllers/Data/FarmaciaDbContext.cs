using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace farmaciaJaveriana.Controllers.Data
{
    public class FarmaciaDbContext : IdentityDbContext
    {

        public FarmaciaDbContext(DbContextOptions<FarmaciaDbContext> options)
        : base(options)
        {
        }
    }
}