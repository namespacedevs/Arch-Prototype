using System.Collections.Generic;
using Arch_Prototype.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Arch_Prototype.Application.Controllers
{
    [Route("v1/[controller]")]
    public class BaseController<T> : Controller where T : class
    {
        private IBaseRepository<T> _repository;

        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] T value)
        {
            _repository.Add(value);
        }

        [HttpPut]
        [HttpGet("{id}")]
        public void Update(int id,[FromBody] T value)
        {
           var model = _repository.Get(id);
           _repository.Update(model,value);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            var model = _repository.Get(id);
            _repository.Delete(model);
        }
    }
}