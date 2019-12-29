using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class FaPicContext:DbContext
    {

        public FaPicContext(DbContextOptions<FaPicContext> options)
            : base(options)
        {
        }
        public DbSet<ImageModel> ImageModels { get; set; }


    }
}
