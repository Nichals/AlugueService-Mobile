using AlugueServiceMobile.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AlugueServiceMobile.Model;
using AlugueServiceMobile.DAL;

namespace AlugueServiceMobile.ViewModel
{
    class ConsultaProdutoViewModel
    {
        public ConsultaProdutoViewModel()
        {

            
        }

        public Produto ConsultarProduto(int idProduto)
        {
       

            var listaProduto = ProdutoDAL.GetLista().lista;

            var produtoSelecionado = from v in listaProduto
                                     where v.idProduto == idProduto
                                     select v;

            Produto prodSelecionado = produtoSelecionado.First();
            
            return prodSelecionado;
        }

    }
}
