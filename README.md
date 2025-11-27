# Araras Health Hub

### Descrição

O **Araras Health Hub API** é o core de um sistema robusto e crucial para a gestão da cadeia de suprimentos e distribuição de medicamentos e insumos para as unidades de saúde municipais. A plataforma foi projetada para otimizar e controlar rigorosamente o estoque, o rastreamento de lotes e validades, o controle de custos e todo o fluxo de pedidos, desde a criação até a dispensação final e estorno.

### Arquitetura

O projeto adota a Arquitetura Limpa (Clean Architecture), garantindo a independência das regras de negócio em relação à infraestrutura. Utiliza o padrão CQRS (Command Query Responsibility Segregation) com MediatR para separar as responsabilidades de leitura e escrita, resultando em endpoints de alta performance e um código altamente escalável, testável e aderente aos princípios SOLID.

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

### Funcionalidades Desenvolvidas

#### Cadastro Base (Entidades Primárias)
| Status | Funcionalidade | Descrição |
|:------:|----------------|-------------|
| ✅ | Gerenciamento de Contas | Cadastro completo de contas (`AspNetUsers`), incluindo perfis e escopos de acesso. |
| ✅ | Autenticação e Autorização (JWT) | Login para autenticação por usuário/senha e geração de JSON Web Token. |
| ✅ | Gerenciamento de Funcionários | CRUD (Cadastro, Leitura, Atualização, Deleção Lógica) dos dados pessoais dos colaboradores (`Employees`). |
| ✅ | Gerenciamento de Unidades | CRUD de unidades (`Facilities`), gerenciando endereços e contatos. |
| ✅ | Gerenciamento de Fornecedores | CRUD completo para cadastro e manutenção de fornecedores (`Suppliers`) de insumos e medicamentos. |
| ✅ | Gerenciamento de Produtos | CRUD de produtos (`Products`) com informações essenciais. |
| ❌ | Gerenciamento de Permissões | Configuração e gestão de perfis e suas respectivas permissões. |

#### Fluxo de Estoque, Recebimento e Custo
| Status | Funcionalidade | Descrição |
|:------:|----------------|-----------|
| ✅ | Recebimento de Produtos | Registro de entradas (`Receivings`) no estoque, associando a nota fiscal, fornecedor e itens recebidos. |
| ✅ | Controle de Estoque e Lotes | Visão consolidada do estoque (`Stocks`), gestão de quantidades mínimas e rastreamento detalhado por lote (`StockLots`), incluindo data de validade.. |
| ✅ | Controle de Custo Médio | Cálculo e atualização do custo médio unitário (`StockCosts`) dos produtos em tempo real com base nos recebimentos. |
| ✅ | Ajuste Manual de Estoque | Funcionalidade para ajustes de inventário (perdas, ganhos, quebras) por meio de um registro justificado (`StockAdjustments`). |
| ✅ | Estorno de Dispensação | Processamento de devoluções de itens dispensados para o estoque, revertendo a saída e atualizando o custo (`DispenseReturns`). |
| ❌ | Sistema de Alertas e Notificações | Geração e gerenciamento de alertas operacionais (Estoque Mínimo, Validade Próxima). |

#### Fluxo de Pedido e Dispensação
| Status | Funcionalidade | Descrição |
|:------:|:---------------|:----------|
| ✅ | Criação e Gestão de Pedidos | Criação de pedidos de unidades com fluxo de aprovação e rastreamento de status (`Orders` e `OrderStatuses`). |
| ✅ | Separação e Reserva FEFO/FIFO | Reserva automática de lotes (`OrderItemLots`) com base na validade/ordem de chegada, atualização do status de estoque e rastreabilidade da separação. |
| ✅ | Dispensação/Saída | Finalização do pedido, registrando a saída efetiva dos itens do estoque e a respectiva baixa em lote (`OrderItemLots`). |

#### Rastreabilidade e Auditoria
| Status | Funcionalidade | Descrição |
|:------:|:---------------|:----------|
| ✅ | Movimentação de Estoque | Registro detalhado de todas as entradas, saídas e ajustes de produtos (`StockMovements`), garantindo a rastreabilidade completa e o histórico de transações por lote. |
| ✅ | Auditoria de Entidade | Implementação de campos de auditoria (CreatedOn, UpdatedOn) e deleção lógica (IsActive) em todas as entidades do sistema. |
| ❌ | Logs de Auditoria | Gravação detalhada de todas as alterações em campos específicos (quem, o que, quando e o valor antigo/novo) em entidades críticas. |
| ❌ | Módulo de Relatórios | Endpoints otimizados para extração de dados gerenciais e operacionais. |

#### Legenda de Status
| Símbolo | Significado |
|:-------:|:------------|
| ✅ | Implementado: A funcionalidade está completa e operacional. |
| 🚧 | Em Progresso: A funcionalidade está em desenvolvimento ativo. |
| ❌ | Pendente: A funcionalidade ainda não foi iniciada ou está suspensa. |
