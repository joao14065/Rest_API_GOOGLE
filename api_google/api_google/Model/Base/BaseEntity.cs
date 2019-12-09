using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_google.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("datacriacao")]
        public DateTime DataCriacao { get; set; }
        [Column("dataalteracao")]
        public DateTime DataAlteracao { get; set; }
        [Column("excluido")]
        public bool Excluido { get; set; }

        public BaseEntity()
        {
            this.Id = 0;
            this.DataCriacao = DateTime.Now;
            this.DataAlteracao = DateTime.Now;
            this.Excluido = false;
        }
    }
}
