using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    public class ConfiguracaoDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Configuracao> lista { get; set; }
        public Configuracao configuracao { get; set; }
    }
}