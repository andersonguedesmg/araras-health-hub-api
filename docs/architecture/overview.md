# Arquitetura do Projeto - ArarasHealthHub

---

## 1. Visão Geral

O projeto ArarasHealthHub segue os princípios de:

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Separação clara de responsabilidades por camada
- Baixo acoplamento entre Application e Infrastructure
- Tratamento centralizado de exceções
- Padronização de respostas utilizando Result`<T>` e ProblemDetails (RFC 7807)

O objetivo é garantir:

- Escalabilidade
- Testabilidade
- Manutenibilidade
- Clareza estrutural
- Evolução sustentável do sistema

---

## 2. Estrutura de Camadas

### 2.1 Domain

Responsável por:

- Entidades
- Value Objects
- Enums
- Regras centrais de negócio

Regras:

- Não depende de nenhuma outra camada
- Não conhece Infrastructure
- Não conhece API
- Não contém lógica de persistência

---

### 2.2 Application

Responsável por:

- Commands
- Queries
- Handlers
- Validators
- DTOs (Responses)
- Interfaces de serviços (ex: ITokenService)
- Pipeline Behaviors

Regras:

- Não deve depender de HttpContext
- Não deve usar UserManager diretamente
- Não deve acessar banco fora de abstrações
- Queries devem usar projeção direta
- Não usar Include quando projeção resolver
- Exceções de domínio devem ser lançadas aqui

---

### 2.3 Infrastructure

Responsável por:

- Persistência (EF Core)
- Configuração de entidades
- Implementação de serviços externos
- Implementação de interfaces da Application

Regras:

- Pode depender de Application
- Não deve conter regra de negócio
- Configurações de relacionamento ficam aqui

---

### 2.4 API

Responsável por:

- Controllers
- Configuração de DI
- Middlewares
- Policies de autorização
- Autenticação

Regras:

- Apenas orquestra requisições
- Não contém regra de negócio
- Delegar lógica à Application via MediatR
- Suportar CancellationToken
- Converter exceções em ProblemDetails

---

## 3. Padrão CQRS

- Commands alteram estado
- Queries apenas consultam dados

Regras:

- Commands retornam Result ou Result`<T>`
- Queries retornam Result`<T>` ou PagedResult`<T>`
- Queries não devem modificar estado

---

## 4. Modelo de Resposta

### 4.1 Sucesso

Utiliza Result ou Result`<T>`

Estrutura:

{ "isSuccess": true, "message": "Mensagem clara ao usuário", "data": { }
}

### 4.2 Paginação

Utiliza PagedResult`<T>`

Inclui:

- pageNumber
- pageSize
- totalCount
- totalPages
- data

### 4.3 Erros

Erros são tratados exclusivamente via Exceptions e convertidos em
ProblemDetails.

Formato (RFC 7807):

{ "type": "https://httpstatuses.com/400", "title": "Erro de validação",
"status": 400, "detail": "Ocorreram erros de validação.", "errors": {
"Email": \["Email inválido"\] } }

---

## 5. Exceções Customizadas

- DomainException
- ApplicationValidationException
- NotFoundException
- UnauthorizedException
- ForbiddenException

Regra:

Exceptions representam falhas. Result representa sucesso.

---

## 6. Autorização

- Policy-Based Authorization
- Claims geradas via TokenService
- Roles e Scopes definidos por Enums
- Application não acessa HttpContext

---

## 7. Padrões de Nomeação

Commands: `<CreateEntidade>Command`

Queries: `<GetEntidade>Query`

Responses: `<Entidade>Response`
`<Entidade>ListItemResponse`

Validators: `<Classe>Validator`

---

## 8. Governança do Projeto

- Seguir padrão de commit definido em commit-pattern.md
- Cada feature deve possuir documentação própria
- Não misturar responsabilidades em um único commit
- Manter baixo acoplamento
- Evitar dependências circulares

---

## 9. Objetivo Estratégico

Garantir que o projeto:

- Permaneça organizado conforme cresce
- Permita onboarding rápido
- Seja auditável
- Seja sustentável a longo prazo
