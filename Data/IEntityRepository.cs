using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinaleProject.Models;

namespace FinaleProject.Data
{
    public interface IEntityRepository
    {
        void Add<T>(T entity) where T:class;
        void Delete<T>(T entity) where T : class;
        bool SaveAll();

        List<CarModel> GetCarModelsList();
        List<Photo> GetPhotosByCarModels(int carModelId);
        CarModel GetCarModelsById(int carModelId);
        Photo GetPhoto(int id);
    }
}
