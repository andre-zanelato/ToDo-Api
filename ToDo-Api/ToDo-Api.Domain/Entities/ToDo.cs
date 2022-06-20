using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDo_Api.Domain.Entities
{
    public class ToDo
    {
        //Annotations serve apenas para nomear as tabelas no banco de dados
        [Column("id")]
        public long Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("completo")]
        public bool Completo { get; set; }

        [Column("data_inclusao")]
        public DateTime DataInclusao { get; set; }

        [Column("data_alteracao")]
        public DateTime? DataAlteracao { get; set; }

        public ToDo()
        {
            Descricao = string.Empty;
            Completo = false;
            DataInclusao = DateTime.Now;
            DataAlteracao = null;
        }
    }
}
