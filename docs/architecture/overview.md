# Arquitetura do Projeto — Araras Health Hub

Documento central de arquitetura do sistema.

## 1. Visão Geral

O Araras Health Hub é uma plataforma para gestão logística de medicamentos e insumos da rede municipal de saúde.

#### O sistema contempla todo o ciclo operacional:

- Recebimento de produtos
- Controle de estoque
- Controle de lotes
- Controle de validade
- Controle de custo médio
- Gestão de pedidos
- Aprovação de pedidos
- Separação baseada em FEFO
- Dispensação
- Estornos
- Rastreabilidade completa de movimentações

## 2. Objetivos Arquiteturais

#### A arquitetura foi projetada para garantir:

- Alta coesão
- Baixo acoplamento
- Escalabilidade
- Testabilidade
- Manutenibilidade
- Evolução sustentável
- Separação explícita de responsabilidades

## 3. Princípios Adotados

#### O projeto utiliza:

- Clean Architecture
- CQRS
- Domain-Driven Design (DDD Lite)
- Repository Pattern
- Service Layer
- Dependency Injection
- Fluent Validation
- ProblemDetails (RFC 7807)
- Policy-Based Authorization

## 4. Estrutura de Camadas

```text
┌─────────────────────────┐
│        API Layer        │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│    Application Layer    │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│      Domain Layer       │
└────────────┬────────────┘
             │
┌────────────▼────────────┐
│   Infrastructure Layer  │
└─────────────────────────┘
```

## 5. Domain Layer

#### Responsável por representar o núcleo do negócio.

Contém:

- Entities
- Enums
- Value Objects
- Regras de negócio

Diretrizes:

- Não depende de nenhuma outra camada
- Não conhece banco de dados
- Não conhece HTTP
- Não conhece EF Core
- Não conhece MediatR

#### As entidades são responsáveis por proteger seus próprios invariantes.

Falhas de domínio são representadas por:

- DomainException
- DomainRuleException

## 6. Application Layer

#### Responsável pelos casos de uso do sistema.

Contém:

- Commands
- Queries
- Handlers
- Validators
- Responses
- Services
- Interfaces
- Exceptions

### 6.1 Commands

#### Commands representam operações que alteram estado.

Exemplos:

- CreateOrderCommand
- ApproveOrderCommand
- SeparateOrderCommand
- FinalizeOrderCommand
- CancelOrderCommand

Diretrizes:

- Alteram estado
- Nunca executam consultas complexas
- Retornam Result ou Result<T>

### 6.2 Queries

#### Queries representam operações de leitura.

Exemplos:

- GetOrderByIdQuery
- GetAllOrdersQuery
- GetOrderPickingDetailsQuery

Diretrizes:

- Não alteram estado
- Devem utilizar projeção direta quando possível
- Devem utilizar paginação quando aplicável

### 6.3 Services

#### Services encapsulam regras de negócio complexas e reutilizáveis.

Atuam como orquestradores de processos.

Exemplos atuais:

### Orders

- IOrderCreationService
- IOrderApprovalService
- IOrderPickingService
- IOrderSeparationService
- IOrderFinalizationService
- IOrderCancellationService
- IOrderReturnService

### Receivings

- IInventoryEntryService

Responsabilidades típicas:

- Coordenar múltiplos repositórios
- Aplicar regras transacionais
- Centralizar lógica compartilhada
- Evitar duplicação entre handlers

### 6.4 Validators

#### Responsáveis apenas por validações básicas.

Exemplos:

- Campos obrigatórios
- Limites de tamanho
- Formato de dados

Não devem:

- Consultar banco
- Executar regras de negócio
- Manipular entidades

## 7. Infrastructure Layer

#### Responsável pelos detalhes técnicos.

Contém:

- EF Core
- Repositories
- Migrations
- Configurações de entidades
- Serviços externos

Diretrizes:

- Pode depender da Application
- Não deve conter regra de negócio
- Não deve retornar DTOs
- Deve retornar entidades ou projeções específicas

### 7.1 Persistência

#### Banco principal:

- SQL Server

#### ORM:

- Entity Framework Core

Características:

- Fluent API
- Check Constraints
- DeleteBehavior.Restrict
- Soft Delete
- Auditoria automática

## 8. API Layer

#### Responsável pela exposição HTTP.

Contém:

- Controllers
- Middlewares
- Configurações
- Autorização

Diretrizes:

- Não contém regra de negócio
- Apenas delega para MediatR
- Utiliza BaseApiController
- Utiliza CancellationToken

## 9. CQRS

#### O projeto adota separação explícita entre leitura e escrita.

### Escrita

Command → Handler → Service → Repository

### Leitura

Query → Handler → Repository

Benefícios:

- Responsabilidades isoladas
- Código mais simples
- Melhor escalabilidade
- Melhor testabilidade

## 10. Modelo de Resposta

#### O sistema utiliza:

- Result
- Result<T>
- PagedResult<T>

Utilizados exclusivamente para operações bem-sucedidas.

### Paginação

#### Consultas paginadas retornam:

- PageNumber
- PageSize
- TotalCount
- TotalPages
- Data

## 11. Tratamento de Erros

#### Falhas são representadas por Exceptions.

O middleware global converte exceções para ProblemDetails (RFC 7807).

Tipos utilizados:

- ApplicationValidationException
- NotFoundException
- UnauthorizedException
- ForbiddenException
- DomainException
- DomainRuleException

Diretriz:

- Result representa sucesso
- Exceptions representam falhas

## 12. Segurança

#### Autenticação:

- JWT Bearer

#### Autorização:

- Policy-Based Authorization

Características:

- Claims
- Scopes
- Policies
- ASP.NET Identity

A camada Application nunca acessa HttpContext.

## 13. Convenções de Projeto

### Commands

```text
<CreateEntity>Command
<UpdateEntity>Command
<DeleteEntity>Command
```

### Queries

```text
<GetEntityById>Query
<GetAllEntities>Query
```

### Responses

```text
<Entity>Response
<Entity>ListItemResponse
```

### Validators

```text
<ClassName>Validator
```

### Services

```text
<IEntityService>
<EntityService>
```

## 14. Documentação

#### A documentação está organizada em:

```text
docs/
├─ architecture/
│  └─ overview.md
└─ features/
   ├─ accounts.md
   ├─ employees.md
   ├─ facilities.md
   ├─ orders.md
   ├─ products.md
   ├─ receivings.md
   ├─ stocks.md
   └─ suppliers.md
```

Cada feature deve possuir documentação própria.

## 15. Governança

#### Regras obrigatórias:

- Commits seguem commit-pattern.md
- Features possuem documentação própria
- Não misturar responsabilidades em um único commit
- Não criar abstrações desnecessárias
- Não duplicar regras de negócio
- Priorizar clareza sobre complexidade

## 16. Objetivo Estratégico

#### Garantir que o sistema:

- Cresça sem degradação arquitetural
- Permita onboarding rápido
- Seja facilmente auditável
- Seja previsível
- Seja sustentável a longo prazo
- Mantenha alta qualidade técnica
