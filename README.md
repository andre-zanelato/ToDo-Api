# Api de gerenciamento de TODO's utilizando .NET 5

**Api criada utilizando uma arquitetura em Camadas com conceitos de DDD**

# **Guia para rodar a api**
- Alterar a connection string no appsetting.Development.json (Postgres)
- Criar um database com o nome definido na connection string
- Definir o projeto .Application como projeto de inicialização
- Rodar a migration pelo terminal com o comando `dotnet ef database update -s ../ToDo-Api.Application`
- Rodar a Api
