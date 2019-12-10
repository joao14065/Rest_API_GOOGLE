using api_google.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_google.Model
{
    [Table("usuario")]
    public class Usuario : BaseEntity
    {
        [Column("nome")]
        public string Nome { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("telefone")]
        public string Telefone { get; set; }
        [Column("cep")]
        public string Cep { get; set; }
        [Column("numero")]
        public string Numero { get; set; }
        [Column("datanascimento")]
        public string DataNascimento { get; set; }
        [Column("photo2")]
        public string Photo2 { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }
        [Column("photo")]
        public Byte[] Photo { get; set; }   

    }
}
