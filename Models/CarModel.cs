using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace FinaleProject.Models
{
    public class CarModel
    {
        public CarModel()
        {
            Photos = new List<Photo>();
        }


        public int Id  { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }

        public List<Photo> Photos { get; set; }
        //public Brands Brands { get; set; }
        public User User { get; set; }
    }
}
