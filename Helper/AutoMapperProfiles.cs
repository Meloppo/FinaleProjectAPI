using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinaleProject.Dto;
using FinaleProject.Models;

namespace FinaleProject.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CarModel, CarModelsDto>().ForMember(t => t.PhotoUrl, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); });


            CreateMap<CarModel, CarModelDetailDto>();
            CreateMap<Photo, PhotoAddDto>();
            CreateMap<PhotoFromCloud, Photo>();
            CreateMap<Photo, PhotoFromCloud>();
        }


    }
}
