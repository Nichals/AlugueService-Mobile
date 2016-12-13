using System;
using System.Collections.Generic;

namespace AlugueServiceMobile.Model
    {
    public class PreAluguel
        {
        public PreAluguel()
            {

            }
        public int idPreAluguel { get; set; }
        public int operadorCriador { get; set; }
        public Cliente cliente { get; set; }
        public Configuracao configuracao { get; set; }
        public long dataPrevista { get; set; }
        public int statusPreAluguel { get; set; }
        public float valorAluguel { get; set; }
        public List<Produto> listaProdutos { get; set; }
    }
    }