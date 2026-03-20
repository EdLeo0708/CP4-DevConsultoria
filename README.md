# DevConsultoria - CP4 C# Development

## Equipe
Mome: Edson Leonardo Pacheco Navia
RM: 553737

## Sobre o Projeto
Sistema de Consultoria em Desenvolvimento de Software utilizando ASP.NET Core MVC 8.

O cliente visualiza os cards de serviços (nome, descrição, tempo de resposta) na tela principal. 
Ao escolher um serviço, preenche nome e email para enviar a solicitação.
O Tech Líder acessa o dashboard para aprovar/reprovar e encaminhar ao dev via WhatsApp.

## Tecnologias
- ASP.NET Core MVC 8
- C#
- Bootstrap
- Bootstrap Icons
- Claims Authentication
- JavaScript Vanilla 

## Como Rodar
```
Cmd
cd DevConsultoria
dotnet run

```

URL para visualizar `https://localhost:5001`

## Login do Admin *Exemplo!!!*
- **Usuário:** admin
- **Senha:** admin123

## Funcionalidades
- Tela principal com cards dos serviços (nome, descrição, tempo resposta)
- Modal de solicitação com nome, email e WhatsApp
- Controller Admin com [Authorize(Roles = "TechLider")]
- Autenticação via Claims (Cookie Authentication)
- Layout.cshtml com verificação de login
- Program.cs configurado com rotas e autenticação
- Estilização com Bootstrap 5
- Layout dinâmico e responsivo
