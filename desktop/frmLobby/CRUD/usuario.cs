using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace WindowLobby.crud
{
    public static class Usuario
    {
        private static readonly HttpClient client =
            new HttpClient();

        public static async Task<string> Login(
            string emailUsu,
            string senhaUsu
        )

        {
            string url = "http://127.0.0.1:8000/login";

            var dados = new
            {
                email = emailUsu.Trim(),
                senha = senhaUsu.Trim()
            };

            string json =
                JsonSerializer.Serialize(dados);

            StringContent content =
                new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json"
                );

            HttpResponseMessage resposta =
                await client.PostAsync(
                    url,
                    content
                );

            if (!resposta.IsSuccessStatusCode)
            {
                return null;
            }

            string respostaJson =
                await resposta.Content
                .ReadAsStringAsync();

            return respostaJson;
        }

        public static async Task<string> GetUsuarios(
            string token
        )
        {
            string url =
                "http://127.0.0.1:8000/usuarios";

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