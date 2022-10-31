using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile,CarImage carImage);
        IResult Update(CarImage carImage,IFormFile formFile);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetImagesbyCarId(int carId);
        IDataResult<CarImage> GetImagesById(int Id);
        IDataResult<List<CarImage>> GetAll();
    }
}
