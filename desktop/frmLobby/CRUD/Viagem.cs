using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowLobby.CRUD
{
    public static class Viagem
    {
        private static readonly HttpClient client =
            new HttpClient();

        public static async Task<string> GetViagens(
            string token
        )
        {
            string url =
                "http://127.0.0.1:8000/grupos";   

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
