using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using System.Security.Permissions;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }
        [SecuredOperation("brand.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<Brand> GetbyId(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == brandId));
        }
        [CacheAspect]
        [PerformanceAspect(10)]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }
        [SecuredOperation("brand.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        [CacheAspect]
        [TransactionScopeAspect]
        public IResult ITransactionalTest(Brand brand)
        {
            Add(brand);
            if (brand.BrandName!.Length<10)
            {
                throw new Exception("");
            }
            Add(brand);
            return null;
        }
    }
}
