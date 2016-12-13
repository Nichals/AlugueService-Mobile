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
    class PreAluguelDAL
    {
        public static PreAluguelDTO cadastrar(PreAluguel pPreAluguel)
        {
            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/PreAluguel/Cadastrar";

            var httpClient = new HttpClient();
            
            var json = JsonConvert.SerializeObject(pPreAluguel);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = httpClient.PostAsync(WebServiceUrl, httpContent).Result;
            var jsonResult = result.Content.ReadAsStringAsync().Result;
            var preAluguelDTO = JsonConvert.DeserializeObject<PreAluguelDTO>(jsonResult);

            return preAluguelDTO;
        }

        public static PreAluguelDTO GetLista()
        {
            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/PreAluguel/Pesquisar";

            var httpClient = new HttpClient();

            var json = httpClient.GetStringAsync(WebServiceUrl).Result;

            var produtoDTO = JsonConvert.DeserializeObject<PreAluguelDTO>(json);

            return produtoDTO;
        }
    }
}
