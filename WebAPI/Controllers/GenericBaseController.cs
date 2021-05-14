using Business.Abstract;
using Core.Entities;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //This class is base for CRUD operations.
    //Thanks to this class, CRUD operations can be performed for each controller without code repetition.
    public class GenericBaseController<T, TService> : ControllerBase
        where TService : IServiceBase<T>
        where T : class, IEntity, new()
    {
        protected TService _service;

        public GenericBaseController(TService tService) => this._service = tService;

        [HttpPost("add")]
        public virtual IActionResult Add(T entity) => GetResponseByResultSuccess(_service.Add(entity));

        [HttpPost("update")]
        public virtual IActionResult Update(T entity) => GetResponseByResultSuccess(_service.Update(entity));

        [HttpPost("delete")]
        public virtual IActionResult Delete(T entity) => GetResponseByResultSuccess(_service.Delete(entity));

        protected IActionResult GetResponseByResultSuccess(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
