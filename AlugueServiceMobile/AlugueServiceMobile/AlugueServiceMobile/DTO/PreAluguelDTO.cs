using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    class PreAluguelDTO 
    {
        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<PreAluguel> lista { get; set; }
        public PreAluguel preAluguel { get; set; }
    }
}