using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDashboardBackend {
    public partial class NorthwindContext : DbContext {
        public NorthwindContext() {

        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options) {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}
