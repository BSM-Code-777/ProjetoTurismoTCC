Esse arquivo serve para guardar o código-fonte do Trabalho de Conclusão de Curso de **Bruno Ares Conceição de Oliveira**, **Bruno Silva Maciel**, **Alex Santos Reis Filho** e **Ana Júlia Reis Pinheiro**, do **SENAI Centro de Tecnologia Albano Franco** (CETAF-SE).
Abaixo vem as instruções de uso:

# Funcionalidades
- Cadastro de Clientes: Usuários podem entrar no site e cadastrarem-se como Clientes;
- Controle de Acesso: Utilizando o e-mail "" e a senha "", é possível acessar a área exclusiva para Gerentes;
- Cadastro de Viagens e Sugestões: Clientes cadastrados podem cadastrar uma viagem entre vários pontos turísticos, além de poderem enviar sugestões para o Gerente;
- Serviço Premium: Clientes podem se inscrever em alguns dos serviços Prenium disponíveis, com data e preços fixos;
- Gerenciamento: Gerentes podem ver dados que Clientes não podem ver, como cadastrar e visualizar Clientes, Viagens, Pontos Turísticos e outros aspectos do banco de dados.

# Tecnologias Usadas
- **Backend:** ASP.Net Core MVC 6
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework
- **Controle de Versão:** Git

# Instalação
## Pré-Requisitos
- [.NET Core SDK] (https://dotnet.microsoft.com/en-us/download)
- [SQL Server] (https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Git] (https://git-scm.com/downloads)

## Passos para instalação:
1. Clone o repositório:
```
git clone https://github.com/BSM-Code-777/ProjetoTurismoTCC
cd Projeto Turismo
```
2. Configure o banco de dados no appsettings.json:
  ```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=seu_servidor;Database=ProjetoTurismoDB;User Id=seu_usuario;Password=sua_senha;"
  }
}
```
3. Execute as migrações do Entity Framework para criar o banco de dados:
```
dotnet ef database update
```
4. Execute e aplicação:
```
dotnet run
```

# Como Usar:
1. Acesse a aplicação no navegador através de endereço local (pode mudar, procure saber mais):
2. Utilize o menu de navegação para se cadastrar no sistema e cadastrar viagens, sugestões e assinaturas premium.
3. Caso quiser utilizar as funções de Gerente, utilize o e-mail "admTurismo@senai.com" e a senha "Turismo@005008!".

## Contato
- Email: bruno.a.oliveira7@aluno.senai.br

## Referências
- Livro: "ASP.NET Core MVC: Aplicações modernas em conjunto com o Entity Framework" - Everton Coimbra de Araújo
- Site: [ASP.NET Core Tutorials for Beginners and Professionals](https://dotnettutorials.net/course/asp-net-core-tutorials/)
