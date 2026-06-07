# Araras Health Hub - API

### Visão Geral

O **Araras Health Hub** é uma plataforma corporativo desenvolvido para suportar toda a cadeia logística de medicamentos e insumos da rede municipal de saúde, desde o recebimento de produtos até sua dispensação final.

#### A solução garante:

- Controle de estoque
- Controle de lotes e validade
- Cálculo de custo médio ponderado
- Recebimento de produtos
- Fluxo de pedidos
- Separação e dispensação
- Estornos
- Auditoria operacional
- Rastreabilidade completa de movimentações

Foi desenvolvido utilizando Clean Architecture, CQRS, MediatR e Entity Framework Core, priorizando escalabilidade, manutenibilidade e separação clara de responsabilidades.

#### Principais Recursos:

- Gestão centralizada de estoque
- Controle de lotes e validade
- Controle de custo médio automático
- Recebimento de medicamentos e insumos
- Fluxo completo de pedidos
- Separação baseada em FEFO/FIFO
- Dispensação e estorno
- Auditoria operacional
- Histórico completo de movimentações

### Arquitetura

#### Padrões adotados:

- Clean Architecture
- CQRS
- Repository Pattern
- Domain-Driven Design (DDD Lite)
- Service Layer
- Result Pattern
- ProblemDetails
- FluentValidation
- JWT Authentication

#### Visão de Camadas

```text
┌─────────────────────────┐
│        API Layer        │
│ Controllers / Endpoints │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│    Application Layer    │
│    Commands / Queries   │
│    MediatR Handlers     │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│      Domain Layer       │
│    Entities / Rules     │
│     Business Logic      │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│   Infrastructure Layer  │
│   EF Core / SQL Server  │
│   External Services     │
└─────────────────────────┘
```

#### Estrutura

```text
docs/
├── architecture
└── features
src/
├── ArarasHealthHub.Api
├── ArarasHealthHub.Application
├── ArarasHealthHub.Domain
├── ArarasHealthHub.Infrastructure
└── ArarasHealthHub.Shared
tests/
├── ArarasHealthHub.IntegrationTests
└── ArarasHealthHub.UnitTests
```

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

### Executando localmente

#### Clone o repositório

```bash
git clone https://github.com/andersonguedesmg/araras-health-hub-api.git
```

#### Acesse a pasta do projeto no terminal

```bash
cd araras-health-hub-api/
```

#### Atualize o banco de dados com as migrações

```bash
dotnet ef database update --project src/ArarasHealthHub.Infrastructure --startup-project src/ArarasHealthHub.Api
```

#### Inicie a aplicação

```bash
dotnet clean
dotnet restore
dotnet build
dotnet watch --project src/ArarasHealthHub.Api run
```

#### Acesse a documentação da API no navegador

```bash
http://localhost:5288
```

### Documentação Funcional

#### Features:

- Accounts
- Employees
- Facilities
- Main-categories
- Orders
- Packaging-types
- Products
- Receivings
- Stocks
- Subcategories
- Suppliers

### Segurança

#### A API utiliza:

- JWT Authentication
- ASP.NET Identity
- Controle de acesso baseado em escopos
- Endpoints protegidos por autorização
- Validação de entrada com FluentValidation

### Status Geral

| Módulo                | Status |
| --------------------- | ------ |
| Contas e Autenticação | ✅     |
| Funcionários          | ✅     |
| Unidades              | ✅     |
| Fornecedores          | ✅     |
| Produtos              | ✅     |
| Estoque               | ✅     |
| Recebimentos          | ✅     |
| Pedidos               | ✅     |
| Dispensação           | ✅     |
| Auditoria Básica      | ✅     |
| Permissões            | ❌     |
| Alertas               | ❌     |
| Relatórios            | ❌     |

### Funcionalidades Desenvolvidas

#### Cadastro Base

| Status | Funcionalidade                |
| :----: | ----------------------------- |
|   ✅   | Gerenciamento de Contas       |
|   ✅   | Autenticação JWT              |
|   ✅   | Gerenciamento de Funcionários |
|   ✅   | Gerenciamento de Unidades     |
|   ✅   | Gerenciamento de Fornecedores |
|   ✅   | Gerenciamento de Produtos     |
|   ❌   | Gerenciamento de Permissões   |

#### Estoque, Recebimento e Custos

| Status | Funcionalidade           |
| :----: | ------------------------ |
|   ✅   | Recebimento de Produtos  |
|   ✅   | Controle de Estoque      |
|   ✅   | Controle de Lotes        |
|   ✅   | Controle de Custo Médio  |
|   ✅   | Ajuste Manual de Estoque |
|   ✅   | Estorno de Dispensação   |
|   ❌   | Sistema de Alertas       |

#### Pedidos e Dispensação

| Status | Funcionalidade          |
| :----: | ----------------------- |
|   ✅   | Gestão de Pedidos       |
|   ✅   | Separação FEFO/FIFO     |
|   ✅   | Dispensação de Produtos |

#### Auditoria e Rastreabilidade

| Status | Funcionalidade          |
| :----: | ----------------------- |
|   ✅   | Movimentação de Estoque |
|   ✅   | Auditoria Básica        |
|   ❌   | Logs de Auditoria       |
|   ❌   | Relatórios Gerenciais   |

### Roadmap

- Sistema de permissões por perfil
- Alertas de estoque mínimo
- Alertas de validade próxima
- Logs detalhados de auditoria
- Relatórios operacionais
- Relatórios gerenciais
- Dashboard administrativo
