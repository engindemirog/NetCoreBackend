using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IServiceBase<T>
    {
        IResult Add(T entity); 
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
