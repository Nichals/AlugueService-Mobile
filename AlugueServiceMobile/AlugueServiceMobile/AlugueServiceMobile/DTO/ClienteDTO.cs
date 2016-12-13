using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    public class ClienteDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Cliente> lista { get; set; }
        public Cliente cliente { get; set; }
    }
}