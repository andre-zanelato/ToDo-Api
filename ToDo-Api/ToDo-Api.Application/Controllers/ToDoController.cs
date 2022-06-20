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

        /// <summary>
        /// Listagem de todos os TODO'S
        /// </summary>
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

        /// <summary>
        /// Cadastro de um novo TODO
        /// </summary>
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

        /// <summary>
        /// Alteração de um TODO especifico
        /// </summary>
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

        /// <summary>
        /// Deleta um TODO especifico
        /// </summary>
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
