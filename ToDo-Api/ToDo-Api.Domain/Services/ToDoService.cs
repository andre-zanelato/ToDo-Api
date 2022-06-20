using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_Api.Domain.Entities;
using ToDo_Api.Domain.Interfaces.Repository;
using ToDo_Api.Domain.ViewModels.ToDo.Adicionar;
using ToDo_Api.Domain.ViewModels.ToDo.Alterar;
using ToDo_Api.Domain.ViewModels.ToDo.Consulta;

namespace ToDo_Api.Domain.Services
{
    public class ToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public List<ConsultaToDoViewModel> GetAll()
        {
            try
            {
                var toDos = _toDoRepository.GetAll().Select(x => new ConsultaToDoViewModel
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Completo = x.Completo,
                    DataInclusao = x.DataInclusao,
                    DataAlteracao = x.DataAlteracao
                }).OrderBy(x => x.DataInclusao).ToList();

                return toDos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public long Insert(AdicionarToDoViewModel vm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vm.Descricao))
                    throw new Exception("ToDo deve ter uma descrição");

                var id = _toDoRepository.Insert(new ToDo
                {
                    Descricao = vm.Descricao
                });

                return id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(long id, AlterarToDoViewModel vm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(vm.Descricao))
                    throw new Exception("ToDo deve ter uma descrição");

                var todo = _toDoRepository.Get(id) ?? throw new Exception("ToDo não encontrado");
                todo.Descricao = vm.Descricao;
                todo.Completo = vm.Completo;
                todo.DataAlteracao = DateTime.Now;

                _toDoRepository.Update(todo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var todo = _toDoRepository.Get(id) ?? throw new Exception("ToDo não encontrado");

                _toDoRepository.Delete(todo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
