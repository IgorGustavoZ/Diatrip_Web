using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowLobby.CRUD
{
    public static class Viagem
    {
        private static readonly HttpClient client =
            new HttpClient();

        public static async Task<string> GetViagens(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                System.Diagnostics.Debug.WriteLine("Erro: O token passado para GetViagens está vazio!");
                return null;
            }
            string url =
                "http://127.0.0.1:8000/grupos";
            using (var request = new HttpRequestMessage(HttpMethod.Get, url))
            {
                

                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers
                    .AuthenticationHeaderValue(
                        "Bearer",
                        token
                    );

                HttpResponseMessage resposta =
                    await client.GetAsync(url);

                if (!resposta.IsSuccessStatusCode)
                {
                    return null;
                }

                string respostaJson =
                    await resposta.Content
                    .ReadAsStringAsync();

                return respostaJson;
            }
                
        }
    }
}
