# Escalada.BlazorApp

Escalada.BlazorApp é uma aplicação Blazor que implementa um CRUD simples para gerenciar usuários. Cada usuário possui um nome e um email.



## Tecnologias Utilizadas

- Blazor
- .NET Core
- Entity Framework Core
- MySQL

## Funcionalidades

- Criar um novo usuário
- Ler os detalhes dos usuários
- Atualizar as informações dos usuários
- Deletar usuários

## Pré-requisitos

- .NET SDK 6.0 ou superior
- MySQL


## Instalação

1. Clone o repositório
   ```bash
git clone https://github.com/seuusuario/Escalada.BlazorApp.git
cd Escalada.BlazorApp

2. Configure a string de conexão:
   
Abra o arquivo appsettings.json e ajuste a string de conexão com os detalhes do seu servidor MySQL.
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BancoTeste;User=root;Password=00000123;"
  }
}

3. Instale as dependências do projeto:
    dotnet restore

4. Os comandos de migração:
   dotnet ef migrations add InitialCreate
   dotnet ef database update

Dai para frente é executar o projeto pelo executar padrão ou :
  dotnet run
