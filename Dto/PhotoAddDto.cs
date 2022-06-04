using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FinaleProject.Dto
{
    public class PhotoAddDto
    {

        public PhotoAddDto()
        {

            DateAdded = DateTime.Now;
        }
        public string Url { get; set; }
        public IFormFile FormFile { get; set; }

        public string Description { get; set; }

        public string PublicId { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
