using AlugueServiceMobile.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AlugueServiceMobile.DAL
{
    class ConfiguracaoDAL
    {

        public static string WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/Configuracao";

        public static ConfiguracaoDTO ultimaConfiguracao()
        {
            WebServiceUrl += "/PesquisarUltimo";

            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(WebServiceUrl).Result;

            var configuracaoDTO = JsonConvert.DeserializeObject<ConfiguracaoDTO>(json);

            return configuracaoDTO;
        }
    }
}
