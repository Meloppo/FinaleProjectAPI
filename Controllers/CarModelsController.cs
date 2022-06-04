using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FinaleProject.Data;
using FinaleProject.Dto;
using FinaleProject.Models;

namespace FinaleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private IEntityRepository _entityRepository;
        private IMapper _mapper;

        public CarModelsController(IEntityRepository entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public ActionResult GetCarResult()
        {
            var carModels = _entityRepository.GetCarModelsList();
            var result = _mapper.Map<List<CarModelsDto>>(carModels);
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody] CarModel carModel)
        {
            _entityRepository.Add(carModel);
            _entityRepository.SaveAll();
            return Ok(carModel);
        }


        [HttpGet]
        [Route("detail")]
        public ActionResult GetCarModelById(int id)
        {
            var car = _entityRepository.GetCarModelsById(id);
            var result = _mapper.Map<CarModelDetailDto>(car);
            return Ok(result);
        }


        [HttpGet]
        [Route("photos")]
        public ActionResult GetPhotosByCar(int carModelId)
        {
            var photos = _entityRepository.GetPhotosByCarModels(carModelId);

            return Ok(photos);
        }
    }
}

