using FinaleProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinaleProject.Data
{
    public class DataBContext:DbContext
    {
        public DataBContext(DbContextOptions<DataBContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
