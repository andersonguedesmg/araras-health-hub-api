# Arquitetura do Projeto - ArarasHealthHub

---

## 1. Visão Geral

O projeto ArarasHealthHub segue os princípios de:

- Clean Architecture
- CQRS (Command Query Responsibility Segregation)
- Separação clara de responsabilidades por camada
- Baixo acoplamento entre Application e Infrastructure
- Forte tipagem e imutabilidade de modelos de resposta

O objetivo é garantir:

- Escalabilidade
- Testabilidade
- Manutenibilidade
- Clareza estrutural
- Evolução sustentável do sistema

---

## 2. Estrutura de Camadas

O sistema está organizado nas seguintes camadas:

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

Regras:

- Não deve depender diretamente de HttpContext
- Não deve usar UserManager ou dependências de Identity diretamente
- Não deve acessar banco fora de abstrações definidas
- Queries devem usar projeção direta (sem AutoMapper)
- Não usar Include quando projeção resolver

---

### 2.3 Infrastructure

Responsável por:

- Persistência (EF Core)
- Configuração de entidades
- Implementação de serviços externos
- Implementação de interfaces definidas na Application

Regras:

- Pode depender de Application
- Não deve conter regra de negócio
- Configurações de relacionamento e Owned Types ficam aqui

---

### 2.4 API

Responsável por:

- Controllers
- Configuração de DI
- Middlewares
- Policies de autorização
- Configuração de autenticação

Regras:

- Apenas orquestra requisições
- Não contém regra de negócio
- Deve delegar toda lógica à Application via MediatR
- Deve suportar CancellationToken

---

## 3. Padrão CQRS

O sistema utiliza CQRS:

- Commands alteram estado
- Queries apenas consultam dados

Regras:

- Commands retornam ApiResponse<T>
- Queries retornam ApiResponse<T> ou PagedResponse<T>
- Queries não devem modificar estado
- Handlers não devem conter lógica de autorização baseada em HttpContext

---

## 4. Padrão de Resposta

Todas as respostas seguem um padrão consistente.

### 4.1 ApiResponse<T>

Usado para retornos simples.

### 4.2 PagedResponse<T>

Usado para listagens paginadas.

Regras:

- DTOs devem ser imutáveis (record)
- Não retornar entidades diretamente
- Não retornar null
- Padronizar mensagens de erro

---

## 5. Autorização

O sistema utiliza Policy-Based Authorization.

Regras:

- Autorização aplicada na camada API
- Application não deve acessar HttpContext
- Claims geradas via TokenService
- Roles e Scopes definidos via Enums

---

## 6. Padrões de Nomeação

### Commands

<CreateEntidade>Command

### Queries

<GetEntidade>Query

### Responses

<Entidade>Response
<Entidade>ListItemResponse

### Validators

<Classe>Validator

---

## 7. Boas Práticas Obrigatórias

- Um commit deve seguir o padrão definido em commit-pattern.md
- Uma feature deve possuir documentação em /docs/features
- Não misturar múltiplas responsabilidades no mesmo commit
- Manter baixo acoplamento entre camadas
- Não introduzir dependências circulares

---

## 8. Objetivo Estratégico

Garantir que o projeto:

- Permaneça organizado conforme cresce
- Permita onboarding rápido de novos desenvolvedores
- Seja facilmente auditável
- Seja sustentável a longo prazo
