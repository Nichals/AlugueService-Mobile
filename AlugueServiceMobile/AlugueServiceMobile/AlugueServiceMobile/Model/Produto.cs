namespace AlugueServiceMobile.Model
{
    public class Produto
    {
        private float v1;
        private string v2;

        public int idProduto { get; set; }
        public string nome { get; set; }
        public float valor { get; set; }
        public string tamanho { get; set; }
        public string genero { get; set; }
        public string descricao { get; set; }
        public int status { get; set; }
        public int quantidadeAluguel { get; set; }
        public string diretorioImagem { get; set; }
        public long dataCriacao { get; set; }
        public int? operadorCriador { get; set; }

        // Metodos construtores
        public Produto()
        {

        }

        public Produto(Produto produto)
        {
            idProduto = produto.idProduto;
            nome = produto.nome;
            valor = produto.valor;
            tamanho = produto.tamanho;
            genero = produto.genero;
            descricao = produto.descricao;
            status = produto.status;
            quantidadeAluguel = produto.quantidadeAluguel;
            dataCriacao = produto.dataCriacao;
            operadorCriador = produto.operadorCriador;
        }

        public Produto(int id)
        {
            this.idProduto = id;
        }

        public Produto(int id, float v1, string v2) : this(id)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}