using BuscarCep.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace BuscarCep.Services
{
    class ViaCepService
    {
        private static string UrlBase = "https://viacep.com.br/ws/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            HttpClient cliente = new HttpClient();
            var result = cliente.GetAsync($"{UrlBase}/{cep}/json").GetAwaiter().GetResult();
            var endereco = result.Content.ReadAsAsync<Endereco>().GetAwaiter().GetResult();
            return endereco;
        }
        public static List<Endereco> BuscarCEPViaEndereco(string Uf, string Cidade, string Logradouro)
        {
            HttpClient cliente = new HttpClient();
            var result = cliente.GetAsync($"{UrlBase}/{Uf}/{Cidade}/{Logradouro}/json").GetAwaiter().GetResult();
            var endereco = result.Content.ReadAsAsync<List<Endereco>>().GetAwaiter().GetResult();
            return endereco;
        }
    }
}
