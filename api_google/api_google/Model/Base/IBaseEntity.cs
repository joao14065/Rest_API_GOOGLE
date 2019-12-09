using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_google.Model.Base
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool Excluido { get; set; }
        DateTime DataCriacao { get; set; }
        DateTime DataAlteracao { get; set; }
    }
}
