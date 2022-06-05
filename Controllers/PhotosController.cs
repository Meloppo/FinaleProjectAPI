using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FinaleProject.Data;
using FinaleProject.Dto;
using FinaleProject.Helper;
using FinaleProject.Models;
using Microsoft.Extensions.Options;

namespace FinaleProject.Controllers
{
    [Route("api/CarModels/{carId}/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IEntityRepository _entityRepository;
        private IMapper _mapper;
        private IOptions<CloudinaryConnection> _cloudinaryCon;
        private Cloudinary _cloud;

        public PhotosController(IEntityRepository entityRepository, IMapper mapper, IOptions<CloudinaryConnection> cloudinaryCon)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
            _cloudinaryCon = cloudinaryCon;
            Account acc = new Account(_cloudinaryCon.Value.CloudName, _cloudinaryCon.Value.ApiKey,
                _cloudinaryCon.Value.ApiSecret);
            _cloud = new Cloudinary(acc);
        }

        [HttpPost]
        public ActionResult AddPhotoToCar(int carId,[FromForm] PhotoAddDto photoAddDto)
        {
            var car = _entityRepository.GetCarModelsById(carId);

            if (car==null)
            {
                return BadRequest("kotuhata");
            }
            var file = photoAddDto.FormFile;
            var result = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)

                    };
                    result = _cloud.Upload(uploadParams);
                }
            }
            photoAddDto.Url = result.Url.ToString();
                photoAddDto.PublicId = result.PublicId;
                var photo = _mapper.Map<Photo>(photoAddDto);
                photo.CarModel = car;
                if (!car.Photos.Any(p=>p.IsMain))
                {
                    photo.IsMain = true;
                }
                car.Photos.Add(photo);
                if (_entityRepository.SaveAll())
                {
                    var photoResult = _mapper.Map<PhotoFromCloud>(photo);
                    return CreatedAtRoute("GetPhoto", new { id = photo.Id }, photoResult);
                }
                return BadRequest("w");
        }

        [HttpGet]
        public ActionResult GetPhoto(int id)
        {
            var photoFromDb = _entityRepository.GetPhoto(id);
            var photo = _mapper.Map<PhotoFromCloud>(photoFromDb);
            return Ok(photo);
        }
    }
}
