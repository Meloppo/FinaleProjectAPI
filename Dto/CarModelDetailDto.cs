using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinaleProject.Models;

namespace FinaleProject.Dto
{
    public class CarModelDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string Description { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
