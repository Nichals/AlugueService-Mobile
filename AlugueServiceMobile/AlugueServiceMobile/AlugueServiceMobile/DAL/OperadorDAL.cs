using AlugueServiceMobile.DTO;
using AlugueServiceMobile.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AlugueServiceMobile.DAL
{
    class OperadorDAL
    {
        public static OperadorDTO autenticar(Operador pOperador)
        {

            var WebServiceUrl = "http://10.0.2.2:9999/AlugueServiceWS/WS/Operador/Pesquisar";

            var httpClient = new HttpClient();

            var resultado = httpClient.GetStringAsync(WebServiceUrl).Result;
           
            var operadorDTO = JsonConvert.DeserializeObject<OperadorDTO>(resultado);
            if (operadorDTO.ok)
            {
                var tListaOperador = operadorDTO.lista.Where(operador => operador.login.ToLower().Equals(pOperador.login.ToLower()));
                var tOperador = tListaOperador.First();
                return new OperadorDTO(true, "Operador autenticado com sucesso.", tOperador);
            }
            else
            {
                return new OperadorDTO(false, "Usuario e/ou senha incorreto.");
            }
        }



    }
}
