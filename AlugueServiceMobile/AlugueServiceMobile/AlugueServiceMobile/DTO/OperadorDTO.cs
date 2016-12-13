using AlugueServiceMobile.Model;
using System.Collections.Generic;

namespace AlugueServiceMobile.DTO
{
    public class OperadorDTO
    {
        private bool v1;
        private string v2;
        private Operador tOperador;

        public OperadorDTO(bool ok, string mensagem, Operador tOperador)
        {
            this.ok = ok;
            this.mensagem = mensagem;
            this.tOperador = tOperador;
        }

        public OperadorDTO(bool ok, string mensagem)
        {
            this.ok = ok;
            this.mensagem = mensagem;
        }

        public bool ok { get; set; }
        public string mensagem { get; set; }
        public List<Operador> lista { get; set; }
        public Operador operador { get; set; }

    }
}