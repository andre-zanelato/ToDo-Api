using Microsoft.AspNetCore.Mvc;
using System;
using ToDo_Api.Domain.Services;
using ToDo_Api.Domain.ViewModels.ToDo.Adicionar;
using ToDo_Api.Domain.ViewModels.ToDo.Alterar;

namespace ToDo_Api.Application.Controllers
{
    [ApiController]
    [Route("todo")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var vm = _toDoService.GetAll();
                return Ok(vm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]AdicionarToDoViewModel vm)
        {
            try
            {
                var id = _toDoService.Insert(vm);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:long}")]
        public IActionResult Put(long id, [FromBody] AlterarToDoViewModel vm)
        {
            try
            {
                _toDoService.Update(id, vm);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _toDoService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
