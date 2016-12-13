using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    public class ProdutoDTO
    {

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Produto> lista { get; set; }
        public Produto produto { get; set; }
    }
}