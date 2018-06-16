using ApiJwtEFInMemory.AuthToken;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumingApiJwt
{
    class Program
    {
        private static string _urlBase;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile($"appsettings.json");
            var config = builder.Build();

            _urlBase = config.GetSection("API_Access:UrlBase").Value;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Envio da requisição a fim de autenticar
                // e obter o token de acesso
                HttpResponseMessage respToken = client.PostAsync(
                    _urlBase + "login", new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            ID = config.GetSection("API_Access:UserID").Value,
                            ChaveAcesso = config.GetSection("API_Access:AccessKey").Value
                        }), Encoding.UTF8, "application/json")).Result;

                string conteudo =
                    respToken.Content.ReadAsStringAsync().Result;
                Console.WriteLine(conteudo);

                if (respToken.StatusCode == HttpStatusCode.OK)
                {
                    Token token = JsonConvert.DeserializeObject<Token>(conteudo);
                    if (token.Authenticated)
                    {
                        // Associar o token aos headers do objeto
                        // do tipo HttpClient
                        client.DefaultRequestHeaders.Authorization =
                            new AuthenticationHeaderValue("Bearer", token.AccessToken);

                        ConsultarUsuario(client, "admin");
                    }
                }
            }

            Console.WriteLine("\nFinalizado!");
            Console.ReadKey();
        }

        private static void ConsultarUsuario(HttpClient client, string id)
        {
            HttpResponseMessage response = client.GetAsync(_urlBase + "usuarios/" + id).Result;

            Console.WriteLine();
            if (response.StatusCode == HttpStatusCode.OK)
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            else
                Console.WriteLine("Token provavelmente expirado!");

            Console.ReadKey();
        }
    }
}
