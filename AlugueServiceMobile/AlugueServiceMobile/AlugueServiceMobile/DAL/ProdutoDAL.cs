using AlugueServiceMobile.DTO;
using AlugueServiceMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlugueServiceMobile.DAL
{
    class ProdutoDAL
    {
        public static ProdutoDTO GetLista()
        {
            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/Produto/Pesquisar";

            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(WebServiceUrl).Result;

            var produtoDTO = JsonConvert.DeserializeObject<ProdutoDTO>(json);

            return produtoDTO;
        }

        public static ProdutoDTO alterarStatusProduto(Produto pProduto, int pStatus)
        {
            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/Produto/Atualizar";

            var httpClient = new HttpClient();
            pProduto.status = pStatus;
            var json = JsonConvert.SerializeObject(pProduto);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = httpClient.PutAsync(WebServiceUrl, httpContent).Result;

            var produtoDTO = JsonConvert.DeserializeObject<ProdutoDTO>(json);

            return produtoDTO;
        }
    }
}
