using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal carImageDal;
        IFileHelper fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            this.carImageDal = carImageDal;
            this.fileHelper = fileHelper;
        }
        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImagesLimited(carImage.CarId));
            if (!result.Success)
            {
                return result;
            }
            var imageResult = fileHelper.Upload(formFile);
            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;
            carImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla eklendi.");
        }
        public IResult Delete(CarImage carImage)
        {
            var deleteCarImage = carImageDal.Get(c => c.CarId == carImage.CarId);
            fileHelper.Delete(deleteCarImage.ImagePath);
            carImageDal.Delete(deleteCarImage);
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            List<CarImage> carImagesList = carImageDal.GetAll();
            if (!carImagesList.Any())
            {
                carImagesList = new List<CarImage>();
                carImagesList.Add(new CarImage { ImagePath = fileHelper.DefaultImage() });
                return new SuccessDataResult<List<CarImage>>(carImagesList);
            }
            return new SuccessDataResult<List<CarImage>>(carImagesList);
        }
        public IDataResult<List<CarImage>> GetImagesbyCarId(int carId)
        {
            List<CarImage> carImageGetById = carImageDal.GetAll(c => c.CarId == carId);
            if (!carImageGetById.Any())
            {
                carImageGetById = new List<CarImage>();
                carImageGetById.Add(new CarImage { ImagePath = fileHelper.DefaultImage() });
                return new SuccessDataResult<List<CarImage>>(carImageGetById);
            }
            return new SuccessDataResult<List<CarImage>>(carImageGetById);
        }
        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var imageByCarId = carImageDal.Get(c => c.CarId == carImage.CarId);
            imageByCarId.ImagePath = fileHelper.Update(formFile, imageByCarId.ImagePath).Message;
            imageByCarId.Date = DateTime.Now;
            carImageDal.Update(imageByCarId);
            return new SuccessResult();
        }
        public IResult CheckIfCarImagesLimited(int carId)
        {
            var result = carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Resim ekleme limiti aşıldı.");
            }
            return new SuccessResult();
        }
        public IDataResult<CarImage> GetImagesById(int Id)
        {
            var result = carImageDal.Get(c => c.Id == Id);
            if (result == null)
            {
                return new ErrorDataResult<CarImage>(new CarImage() { Id = Id, ImagePath = fileHelper.DefaultImage() });
            }
            return new SuccessDataResult<CarImage>(result);
        }
    }
}
