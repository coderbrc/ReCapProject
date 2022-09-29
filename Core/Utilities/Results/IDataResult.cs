using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
