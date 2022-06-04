using FinaleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinaleProject.Data
{
    public class EntityRepository : IEntityRepository
    {
        private DataBContext _context;

        public EntityRepository(DataBContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public CarModel GetCarModelsById(int carModelId)
        {
            var carmodel = _context.CarModels.Include(c => c.Photos)
                .SingleOrDefault(c => c.Id == carModelId);
            return carmodel;
        }

        public List<CarModel> GetCarModelsList()
        {
            var carmodels = _context.CarModels.Include(c => c.Photos).ToList();
            return carmodels;
        }

        public Photo GetPhoto(int id)
        {
            var photo = _context.Photos.SingleOrDefault(p => p.Id == id);
            return photo;
        }

        public List<Photo> GetPhotosByCarModels(int carModelId)
        {
            var photos = _context.Photos.Where(p => p.CarModelId == carModelId).ToList();
            return photos;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
