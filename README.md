# Araras Health Hub

### Descrição

O **Araras Health Hub API** é a base para uma plataforma de gestão de estoque e distribuição de medicamentos para unidades de saúde. A API oferece um conjunto de endpoints para gerenciar unidades de saúde, contas de usuário e o fluxo de estoque de medicamentos.

O projeto foi construído seguindo uma arquitetura limpa (Clean Architecture), com a separação clara de responsabilidades entre as camadas de domínio, aplicação, infraestrutura e apresentação. Ele utiliza o padrão CQRS (Command Query Responsibility Segregation) com a biblioteca MediatR, além de seguir os princípios de SOLID, para garantir um código escalável, manutenível e fácil de testar.

### Tecnologias

- [.NET 9.0](https://dotnet.microsoft.com/)
- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/)
- [MediatR](https://github.com/jbogard/MediatR)
- [AutoMapper](https://automapper.org/)
- [FluentValidation](https://docs.fluentvalidation.net/)
- [JWT (JSON Web Tokens)](https://jwt.io/)

### Pré-requisitos

Antes de começar, instale:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/)

### Rodando localmente

Clone o repositório

```bash
git clone https://github.com/andersonguedesmg/araras-health-hub-api.git
```

Acesse a pasta do projeto no terminal

```bash
cd araras-health-hub-api/
```

Atualize o banco de dados com as migrações

```bash
dotnet ef database update --project src/ArarasHealthHub.Infrastructure --startup-project src/ArarasHealthHub.Api
```

Inicie a aplicação

```bash
dotnet watch --project src/ArarasHealthHub.Api run
```

Acesse a documentação da API no navegador

```bash
http://localhost:5288
```

### Features

Gerenciamento de Unidades de Saúde:
- [x]  Cadastro de Unidade
- [x]  Edição de Unidade
- [x]  Exclusão de Unidade (Lógica)
- [x]  Listagem de Unidades
- [x]  Busca de Unidade por ID

Gerenciamento de Contas:
- [x]  Cadastro de Contas
- [x]  Login e Geração de JWT
- [x]  Busca de Conta por ID
- [x]  Edição de Contas
- [x]  Exclusão de Contas (Lógica)
- [x]  Listagem de Contas

Gerenciamento de Fornecedores:
- [x]  Cadastro de Fornecedor
- [x]  Edição de Fornecedor
- [x]  Exclusão de Fornecedor (Lógica)
- [x]  Listagem de Fornecedores
- [x]  Busca de Fornecedor por ID

Gerenciamento de Estoque e Produtos:
- [x]  Cadastro de Produto
- [x]  Edição de Produto
- [x]  Exclusão de Produto (Lógica)
- [x]  Listagem de Produtos
- [x]  Busca de Produto por ID
- [x]  Recebimento de Produtos
- [x]  Saída de Produtos
- [ ]  Inventário de Estoque

Gerenciamento de Pedidos:
- [x]  Cadastro de Pedido
- [x]  Aprovação de Pedido
- [x]  Separação de Pedido
- [x]  Finalização de Pedido
