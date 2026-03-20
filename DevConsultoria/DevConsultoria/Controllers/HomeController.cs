using Microsoft.AspNetCore.Mvc;
using DevConsultoria.Data;
using DevConsultoria.Models;

namespace DevConsultoria.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var problemas = AppData.Problemas;
            return View(problemas);
        }

        [HttpPost]
        public IActionResult Solicitar([FromBody] SolicitacaoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Dados inválidos.");

            var problema = AppData.Problemas.FirstOrDefault(p => p.Id == model.ProblemaId);
            if (problema == null)
                return NotFound("Problema não encontrado.");

            var solicitacao = new Solicitacao
            {
                Id = AppData.GetNextId(),
                NomeCliente = model.NomeCliente,
                EmailCliente = model.EmailCliente,
                NomeWhatsApp = model.NomeWhatsApp,
                ProblemaId = model.ProblemaId,
                Problema = problema,
                DataSolicitacao = DateTime.Now,
                Status = StatusSolicitacao.Pendente
            };

            AppData.Solicitacoes.Add(solicitacao);

            return Ok(new { mensagem = "Solicitação enviada com sucesso! Em breve nossa equipe entrará em contato.", protocolo = solicitacao.Id });
        }
    }
}