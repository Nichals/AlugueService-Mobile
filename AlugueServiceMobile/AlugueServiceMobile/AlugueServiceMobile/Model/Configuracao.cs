using System;

namespace AlugueServiceMobile.Model
{
    public class Configuracao
    {
        public Configuracao()
        {

        }

        public int idConfiguracao { get; set; }
        public float multa { get; set; }
        public float cupom { get; set; }
        public String contrato { get; set; }

    }
}