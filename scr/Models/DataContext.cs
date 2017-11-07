using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPage.Models.Account;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminPage.Models
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> opt)
            : base(opt)
        {
        }
        public DbSet<ApplicationUser> Accounts { get; set; }
    }
}
