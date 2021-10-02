﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Atividade
{
    public class AtividadeService : IAtividadeService
    {
        protected static readonly MediaTypeHeaderValue CONTENT_TYPE = new MediaTypeHeaderValue("application/json");
        private readonly IConfiguration _configuration;

        public AtividadeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Dominio.Model.Atividade>> BuscarAtividades()
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_configuration["ClienteService:BaseUrl"]);
            var response = await httpClient.GetAsync("atividade");


            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<IEnumerable<Dominio.Model.Atividade>>(content);

            return result;
        }

        public async Task<Dominio.Model.Atividade> SalvarAtividade(Dominio.Model.Atividade atividade)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_configuration["ClienteService:BaseUrl"]);
            using var content = new ByteArrayContent(GetByteData(atividade));
            content.Headers.ContentType = CONTENT_TYPE;
            var reponse = await httpClient.PostAsync("atividade", content);

            if (reponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return null;

            var responeContent = await reponse.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Dominio.Model.Atividade>(responeContent);

            return result;
        }

        protected virtual byte[] GetByteData<TRequest>(TRequest requestBody)
        {
            var settings = new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping };
            var body = JsonSerializer.Serialize(requestBody, settings);
            return Encoding.UTF8.GetBytes(body);
        }

    }
}
