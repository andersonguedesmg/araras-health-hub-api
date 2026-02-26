# Arquitetura do Projeto - ArarasHealthHub

---

## 1. Visão Geral

O projeto ArarasHealthHub segue os princípios de:

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Separação explícita de responsabilidades
- Padronização definitiva de responses via Result<T>
- Tratamento centralizado de exceções via ProblemDetails (RFC 7807)
- EF Core com consultas otimizadas (projeção direta)

O objetivo é garantir:

- Escalabilidade previsível
- Alta coesão e baixo acoplamento
- Testabilidade isolada por camada
- Governança arquitetural clara
- Evolução sustentável a longo prazo

---

## 2. Estrutura de Camadas

### 2.1 Domain

Responsável por:

- Entidades
- Value Objects
- Enums
- Regras centrais de negócio

Regras obrigatórias:

- Não depende de nenhuma outra camada
- Não conhece Application, Infrastructure ou API
- Não contém lógica de persistência
- Não contém dependência de framework

---

### 2.2 Application

Responsável por:

- Commands
- Queries
- Handlers
- Validators
- Responses (records imutáveis)
- Interfaces de serviços
- Pipeline Behaviors
- Exceções de aplicação

Diretrizes definitivas:

- Nunca acessar HttpContext
- Nunca acessar banco diretamente (usar abstrações)
- Não utilizar Include quando projeção resolver
- Queries devem usar projeção direta no Select
- Não usar ToLower() em consultas (evitar impacto no SQL Server)
- Commands retornam Result ou Result<T>
- Queries retornam Result<T> ou PagedResult<T>
- Falhas são representadas exclusivamente por Exceptions

---

### 2.3 Infrastructure

Responsável por:

- EF Core
- Configuração de entidades
- Implementação de repositories
- Implementação de serviços externos

Regras:

- Pode depender de Application
- Não deve conter regra de negócio
- Configurações de relacionamento ficam aqui
- Não deve retornar DTOs (retorna entidades)

---

### 2.4 API

Responsável por:

- Controllers
- Middlewares
- Autorização
- Configuração de DI

Regras:

- Não contém regra de negócio
- Apenas delega para MediatR
- Sempre aceitar CancellationToken
- Utilizar BaseApiController
- Converter exceções em ProblemDetails via middleware
- Utilizar ProducesResponseType explícito para erros relevantes

---

## 3. Padrão CQRS

Separação obrigatória:

- Commands alteram estado
- Queries apenas consultam

Regras:

- Commands nunca retornam entidades
- Queries nunca alteram estado
- Toda operação deve ser explícita
- Validators apenas validam formato e consistência básica
- Validação de existência ocorre no Handler

---

## 4. Modelo de Resposta

### 4.1 Sucesso

Utiliza:

- Result
- Result<T>
- PagedResult<T>

Estrutura de sucesso:

{
  "isSuccess": true,
  "message": "Mensagem clara",
  "data": {}
}

### 4.2 Paginação

PagedResult<T> inclui:

- pageNumber
- pageSize
- totalCount
- totalPages
- data

A paginação é aplicada via extensão ApplyPagination.

### 4.3 Erros

Erros são tratados exclusivamente via Exceptions.

Convertidos para ProblemDetails (RFC 7807):

{
  "type": "https://httpstatuses.com/400",
  "title": "Erro de validação",
  "status": 400,
  "detail": "Ocorreram erros de validação.",
  "errors": {
    "Field": ["Mensagem"]
  }
}

Não utilizamos Result para representar falhas.

---

## 5. Exceções Customizadas

- DomainException
- BusinessRuleException
- ApplicationValidationException
- NotFoundException
- UnauthorizedException
- ForbiddenException

Regra arquitetural:

Exceptions representam falhas.
Result representa sucesso.

---

## 6. Autorização

- Policy-Based Authorization
- Claims geradas via TokenService
- Roles e Scopes via Enums
- Application não acessa HttpContext

---

## 7. Padrões de Nomeação

Commands:
<CreateEntidade>Command

Queries:
<GetEntidade>Query
<GetAllEntidade>Query

Responses:
<Entidade>Response
<Entidade>ListItemResponse
<Entidade>CreatedResponse (quando necessário)

Validators:
<Classe>Validator

Handlers:
<Classe>Handler

---

## 8. Governança do Projeto

- Commits devem seguir commit-pattern.md
- Cada feature deve possuir documentação própria
- Não misturar responsabilidades no mesmo commit
- Não criar abstrações desnecessárias
- Evitar arquivos globais de mensagens

---

## 9. Objetivo Estratégico

Garantir que o projeto:

- Cresça sem degradação estrutural
- Permita onboarding rápido
- Seja auditável
- Seja previsível
- Seja sustentável a longo prazo
