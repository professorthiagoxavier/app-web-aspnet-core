using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Threading.Tasks;

namespace AplicacaoWeb.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly IAtividadeService _atividadeService;

        public AtividadeController(IAtividadeService atividadeService)
        {
            _atividadeService = atividadeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/Listar")]
        public async Task<IActionResult> List()
        {
            var atividades = await _atividadeService.BuscarAtividades();

            return View(atividades);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RM, Nome, UrlGitHub, NumeroAtividade")] Atividade model)
        {
            var result = await _atividadeService.SalvarAtividade(model);

            return View(result);
        }
    }
}
