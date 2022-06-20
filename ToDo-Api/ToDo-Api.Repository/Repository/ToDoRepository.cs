using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_Api.Domain.Entities;
using ToDo_Api.Domain.Interfaces.Repository;
using ToDo_Api.Repository.Context;

namespace ToDo_Api.Repository.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public List<ToDo> GetAll()
        {
            try
            {
                return _context.ToDo.ToList();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar consulta de dados");
            }
        }

        public ToDo Get(long id)
        {
            try
            {
                return _context.ToDo.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar consulta de dados");
            }
        }

        public long Insert(ToDo toDo)
        {
            try
            {
                var entity = _context.Add(toDo);
                _context.SaveChanges();
                return entity.Entity.Id;
            }
            catch (Exception)
            {
                throw new Exception("Erro ao inserir dados");
            }

        }

        public void Update(ToDo toDo)
        {
            try
            {
                _context.Update(toDo);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao atualizar dados");
            }

        }

        public void Delete(ToDo toDo)
        {
            try
            {
                _context.Remove(toDo);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao deletar dados");
            }

        }
    }
}
