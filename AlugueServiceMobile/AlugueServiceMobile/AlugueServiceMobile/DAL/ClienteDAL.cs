using AlugueServiceMobile.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AlugueServiceMobile.DAL
{
    class ClienteDAL
    {
        private string WebServiceUrl = "";

        public static ClienteDTO GetLista()
        {
            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/Cliente/Pesquisar";
            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(WebServiceUrl).Result;

            var clienteDTO = JsonConvert.DeserializeObject<ClienteDTO>(json);

            return clienteDTO;
        }
    }
}
