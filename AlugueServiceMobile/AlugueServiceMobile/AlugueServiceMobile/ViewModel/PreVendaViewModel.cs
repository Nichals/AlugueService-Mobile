using AlugueServiceMobile.DAL;
using AlugueServiceMobile.DTO;
using AlugueServiceMobile.Model;
using PropertyChanged;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlugueServiceMobile.ViewModel
{
    [ImplementPropertyChanged]
    class PreVendaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Operador
        Operador operador;
        public Operador Operador
        {
            get { return operador; }
            set
            {
                operador = value;

            }
        }
        #endregion

        #region Cliente
        private Cliente cliente;
        public Cliente Cliente
        {
            get { return cliente; }
            set
            {
                cliente = value;

            }
        }
        public string NomeCliente
        {
            set
            {
                if (!value.Equals(cliente.nome))
                {
                    cliente.nome = value;

                }
            }
            get
            {
                return cliente.nome;
            }
        }
        public IEnumerable<Cliente> ListaClienteBD { get; set; }
        public IEnumerable<Cliente> ListaCliente { get; set; }


        public void PesquisaCliente(string pesquisa)
        {
            var list = ListaCliente.ToList<Cliente>();
            if (list.Count != 0)
            {
                ListaCliente = ListaClienteBD.Where(cliente => cliente.nome.ToLower().Contains(pesquisa.ToLower()));



            }
            else
            {
                CarregaCliente();
                ListaCliente = ListaClienteBD.Where(cliente => cliente.nome.ToLower().Contains(pesquisa.ToLower()));


            }


        }


        private void CarregaCliente()
        {
            ListaClienteBD = new List<Cliente>();
            var tDto = ClienteDAL.GetLista();
            if (tDto.ok)
            {
                var listaClienteAtivo = new List<Cliente>();
                foreach (var cliente in tDto.lista)
                {
                    if (cliente.status == 1)
                    {
                        listaClienteAtivo.Add(cliente);
                    }

                }
                ListaClienteBD = listaClienteAtivo;
            }
        }


        #endregion

        #region PreAluguel


        PreAluguel preAluguel;
        public PreAluguel PreAluguel { get; set; }

        DateTime dataPrevista;
        public DateTime DataPrevista
        {
            get
            {
                return dataPrevista;
            }

            set
            {
                dataPrevista = value;
            }
        }

        #endregion

        #region Produto

        public ObservableCollection<Produto> ListaProdutoSelecionado { get; set; }
        public ObservableCollection<Produto> ListaProdutoBD { get; set; }
        public IEnumerable<Produto> ListaProduto { get; set; }
        public Produto produto;
        public string NomeProduto
        {
            get
            {
                return produto.nome;
            }
            set
            {
                produto.nome = value;
            }
        }
        public int IdProduto
        {
            get
            {
                return produto.idProduto;
            }
            set
            {
                produto.idProduto = value;
            }
        }

        

        public void PesquisaProdutoId(int id)
        {


            ListaProduto = ListaProdutoBD.Where(produto => produto.idProduto.Equals(id));

        }

        public void RemoverProduto(Produto produtoSelecionado)
        {
            if (ListaProdutoSelecionado.Any(p => p.idProduto == produtoSelecionado.idProduto))
            {
                //Altera status do produto para "pré aluguel"
                ProdutoDAL.alterarStatusProduto(produtoSelecionado, 1);
                ListaProdutoSelecionado.Remove(produtoSelecionado);
                OnPropertyChanged("ListaProdutoSelecionado");

            }
            else
            {
                return;
            }
        }

        public void PesquisaProdutoNome(string filtro)
        {
            ListaProduto = ListaProdutoBD.Where(produto => produto.nome.ToLower().Contains(filtro));
        }

        public void AdicionarProduto(Produto produtoSelecionado)
        {
            if (!ListaProdutoSelecionado.Any(p => p.idProduto == produtoSelecionado.idProduto))
            {
                ListaProdutoSelecionado.Add(produtoSelecionado);
                //Altera status do produto para "pré aluguel"
                ProdutoDAL.alterarStatusProduto(produtoSelecionado, 3);
                OnPropertyChanged("ListaProdutoSelecionado");
            }
            else
            {
                return;
            }


        }


        private void CarregaProduto()
        {
            ListaProdutoBD = new ObservableCollection<Produto>();
            var tDto = ProdutoDAL.GetLista();
            if (tDto.ok)
            {
                foreach (var produto in tDto.lista)
                {
                    if (produto.status == 1)
                    {
                        ListaProdutoBD.Add(produto);
                    }

                }
            }

            //var produto = new Produto(1, (float)10, "Terno");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(12, (float)200, "Vestido");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(2, (float)16, "Saia");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(3, (float)20, "Chinelo");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(4, (float)60, "Gravata");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(5, (float)12, "Meia");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(6, (float)12, "Sapato");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(7, (float)12, "Sapato de salto");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(8, (float)12, "Sapato azul");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(9, (float)12, "Vestido azul");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(10, (float)12, "Cueca preta");
            //ListaProdutoBD.Add(produto);
            //produto = new Produto(11, (float)12, "Cueca vermelha");
            //ListaProdutoBD.Add(produto);
        }


        #endregion


        #region Configuração
        private Configuracao configuracao;

        public Configuracao Configuracao
        {
            get
            {
                return configuracao;
            }

            set
            {
                configuracao = value;
            }
        }
        #endregion

        public PreAluguelDTO Salvar()
        {

            preAluguel.cliente = Cliente;
            preAluguel.configuracao = configuracao;
            preAluguel.operadorCriador = Operador.idOperador;
            preAluguel.listaProdutos = ListaProdutoSelecionado.ToList();
            preAluguel.statusPreAluguel = 1;
            preAluguel.valorAluguel = 0;
            preAluguel.dataPrevista = dataPrevista.Ticks;
            foreach (var item in preAluguel.listaProdutos)
            {
                preAluguel.valorAluguel += item.valor;
            }
            var tDto = PreAluguelDAL.cadastrar(preAluguel);
                
            return tDto;
        }



        public PreVendaViewModel()
        {
            this.configuracao = new Configuracao();
            this.operador = Global.operador;
            this.cliente = new Cliente();
            this.produto = new Produto();
            this.preAluguel = new PreAluguel();
            ListaCliente = new List<Cliente>();
            ListaProdutoSelecionado = new ObservableCollection<Produto>();
            ListaProduto = new ObservableCollection<Produto>();
            CarregaCliente();
            CarregaProduto();
            var tDto = ConfiguracaoDAL.ultimaConfiguracao();
            this.configuracao = tDto.configuracao;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
