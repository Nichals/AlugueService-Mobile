using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    class AluguelDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Aluguel> lista { get; set; }
        public Aluguel configuracao { get; set; }
    }
}