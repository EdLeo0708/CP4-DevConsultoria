using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DevConsultoria.Data;
using DevConsultoria.Models;

namespace DevConsultoria.Controllers
{
    [Authorize(Roles = "TechLider")]
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            var solicitacoes = AppData.Solicitacoes.OrderByDescending(s => s.DataSolicitacao).ToList();
            ViewBag.TotalPendentes = solicitacoes.Count(s => s.Status == StatusSolicitacao.Pendente);
            ViewBag.TotalAprovadas = solicitacoes.Count(s => s.Status == StatusSolicitacao.Aprovada);
            ViewBag.TotalReprovadas = solicitacoes.Count(s => s.Status == StatusSolicitacao.Reprovada);
            ViewBag.Devs = AppData.Devs;
            return View(solicitacoes);
        }

        [HttpPost]
        public IActionResult Aprovar([FromBody] AprovarSolicitacaoViewModel model)
        {
            var solicitacao = AppData.Solicitacoes.FirstOrDefault(s => s.Id == model.SolicitacaoId);
            if (solicitacao == null)
                return NotFound();

            solicitacao.Status = model.Aprovado ? StatusSolicitacao.Aprovada : StatusSolicitacao.Reprovada;
            solicitacao.DevDesignado = model.DevDesignado;
            solicitacao.Observacao = model.Observacao;

            string whatsMsg = "";
            if (model.Aprovado)
            {
                whatsMsg = Uri.EscapeDataString(
                    $"Olá {model.DevDesignado}! 🚀\n\nVocê recebeu uma nova solicitação:\n" +
                    $"📋 Serviço: {solicitacao.Problema?.Nome}\n" +
                    $"👤 Cliente: {solicitacao.NomeCliente}\n" +
                    $"📧 Email: {solicitacao.EmailCliente}\n" +
                    $"⏱ Tempo de Resposta: {solicitacao.Problema?.TempoResposta}\n\n" +
                    $"Observação: {model.Observacao}\n\nBoa sorte! 💪"
                );
            }

            return Ok(new
            {
                sucesso = true,
                aprovado = model.Aprovado,
                whatsappMsg = whatsMsg,
                devDesignado = model.DevDesignado
            });
        }
    }
}