using AlugueServiceMobile.DAL;
using AlugueServiceMobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlugueServiceMobile.ViewModel
{
    class ConsultaPreAluguelViewModel
    {
        public ConsultaPreAluguelViewModel()
        {

        }
        public PreAluguel ConsultarPreAluguel(int idPreAluguel)
        {


            var listaPreAluguel = PreAluguelDAL.GetLista().lista;

            var preAluguelSelecionado = from v in listaPreAluguel
                                     where v.idPreAluguel == idPreAluguel
                                     select v;

            PreAluguel prodSelecionado = preAluguelSelecionado.First();

            return prodSelecionado;
        }
    }
}
