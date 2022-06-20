using System;

namespace ToDo_Api.Domain.ViewModels.ToDo.Consulta
{
    public class ConsultaToDoViewModel
    {
        public long Id { get; set; }

        public string Descricao { get; set; }

        public bool Completo { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}
