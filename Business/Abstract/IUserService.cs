using Core.Entities.Concrete;
using Core.Utilities.Results;


namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetbyId(int userId);
        IDataResult<List<User>> GetAll();
    }
}
