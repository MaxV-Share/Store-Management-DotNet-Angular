using App.Services.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Controllers.Base
{

    public abstract class CrudController<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey> : ApiController
        where TEntity : class, new()
        where TCreateRequest : BaseCreateRequest, new()
        where TUpdateRequest : BaseUpdateRequest<TKey>, new()
        where TViewModel : BaseViewModel<TKey>, new()
    {
        private readonly IBaseService<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey> _baseService;
        protected CrudController(ILogger logger, IBaseService<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey> baseService) : base(logger)
        {
            _baseService = baseService;
        }
        [HttpPost]
        public virtual async Task<ActionResult> Post([FromForm] TCreateRequest request)
        {
            if (null == request)
                return BadRequest();
            var result = await _baseService.CreateAsync(request);

            if (null == result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public virtual async Task<ActionResult> Put(TKey id, [FromForm] TUpdateRequest request)
        {
            if (!id.Equals(request.Id))
                return BadRequest();
            var result = await _baseService.UpdateAsync(id, request);
            if (result > 0)
                return NoContent();
            return NotFound();
        }
        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> Delete(TKey id)
        {
            var result = await _baseService.DeleteSoftAsync(id);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpPost("filter")]
        public abstract Task<ActionResult> GetPaging(FilterBodyRequest request);
        [HttpGet("{id}")]
        public virtual async Task<ActionResult> GetById(TKey id)
        {
            var result = await _baseService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}
