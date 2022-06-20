using System.Collections.Generic;
using ToDo_Api.Domain.Entities;

namespace ToDo_Api.Domain.Interfaces.Repository
{
    public interface IToDoRepository
    {
        List<ToDo> GetAll();
        ToDo Get(long id);
        long Insert(ToDo toDo);
        void Update(ToDo toDo);
        void Delete(ToDo toDo);
    }
}
