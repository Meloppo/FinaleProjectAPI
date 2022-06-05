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
            CreateMap<CarModel, CarModelsDto>().ForMember(t => t.Photos, opt => { opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url); });


            CreateMap<CarModel, CarModelDetailDto>();
            CreateMap<PhotoAddDto, Photo>();
            CreateMap<PhotoFromCloud, Photo>();
            CreateMap<Photo, PhotoFromCloud>();
        }


    }
}
