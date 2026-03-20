using DevConsultoria.Models;

namespace DevConsultoria.Data
{
    public static class AppData
    {
        public static List<Problema> Problemas { get; } = new List<Problema>
        {
            new Problema { Id = 1, Nome = "Bug Crítico em Produção", Descricao = "Identificação e correção de erros críticos que afetam o funcionamento do sistema em ambiente de produção.", TempoResposta = "2 horas", Categoria = "Urgente", Preco = 1500, Icone = "bi-bug-fill" },
            new Problema { Id = 2, Nome = "Performance & Otimização", Descricao = "Análise e otimização de consultas, índices de banco de dados e gargalos de performance na aplicação.", TempoResposta = "24 horas", Categoria = "Performance", Preco = 2200, Icone = "bi-speedometer2" },
            new Problema { Id = 3, Nome = "Integração de APIs", Descricao = "Desenvolvimento e integração com APIs externas, webhooks e serviços de terceiros.", TempoResposta = "48 horas", Categoria = "Integração", Preco = 3000, Icone = "bi-plug-fill" },
            new Problema { Id = 4, Nome = "Arquitetura de Sistema", Descricao = "Consultoria e reestruturação da arquitetura do sistema para escalabilidade e manutenibilidade.", TempoResposta = "72 horas", Categoria = "Arquitetura", Preco = 5000, Icone = "bi-diagram-3-fill" },
            new Problema { Id = 5, Nome = "Segurança & Vulnerabilidades", Descricao = "Auditoria de segurança, identificação de vulnerabilidades e implementação de correções.", TempoResposta = "24 horas", Categoria = "Segurança", Preco = 4000, Icone = "bi-shield-lock-fill" },
            new Problema { Id = 6, Nome = "Migração de Banco de Dados", Descricao = "Planejamento e execução de migrações de banco de dados sem downtime.", TempoResposta = "48 horas", Categoria = "Database", Preco = 2800, Icone = "bi-database-fill-gear" },
        };

        public static List<Solicitacao> Solicitacoes { get; } = new List<Solicitacao>();

        public static List<string> Devs { get; } = new List<string>
        {
            "Carlos Silva", "Ana Oliveira", "Pedro Santos", "Maria Costa"
        };

        private static int _nextId = 1;
        public static int GetNextId() => Interlocked.Increment(ref _nextId);
    }
}