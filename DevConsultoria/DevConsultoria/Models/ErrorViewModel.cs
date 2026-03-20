namespace DevConsultoria.Models
{
    public class Problema
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string TempoResposta { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Icone { get; set; } = "bi-code-slash";
    }

    public class Solicitacao
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public string NomeWhatsApp { get; set; } = string.Empty;
        public int ProblemaId { get; set; }
        public Problema? Problema { get; set; }
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public StatusSolicitacao Status { get; set; } = StatusSolicitacao.Pendente;
        public string? DevDesignado { get; set; }
        public string? Observacao { get; set; }
    }

    public enum StatusSolicitacao
    {
        Pendente,
        Aprovada,
        Reprovada
    }

    public class SolicitacaoViewModel
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public string NomeWhatsApp { get; set; } = string.Empty;
        public int ProblemaId { get; set; }
        public string NomeProblema { get; set; } = string.Empty;
    }

    public class LoginViewModel
    {
        public string Usuario { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }

    public class AprovarSolicitacaoViewModel
    {
        public int SolicitacaoId { get; set; }
        public string DevDesignado { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
        public bool Aprovado { get; set; }
    }
}