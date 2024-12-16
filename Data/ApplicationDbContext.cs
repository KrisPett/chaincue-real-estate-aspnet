using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace chaincue_real_estate_aspnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
