using System.Text.Json.Serialization;

namespace Dominio.Model
{
    public class Atividade : Pagination<Atividade>
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("rm")]
        public int RM { get; set; }

        [JsonPropertyName("nome")]
        public string Nome { get; set; }

        [JsonPropertyName("urlGitHub")]
        public string UrlGitHub { get; set; }

        [JsonPropertyName("numeroAtividade")]
        public int NumeroAtividade { get; set; }
    }
}
