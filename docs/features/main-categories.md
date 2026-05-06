# Documentação da Feature: MainCategories

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature MainCategories é responsável pelo gerenciamento completo das categorias principais de produtos do sistema.

Permite:

- Cadastro de categoria principal
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Uma MainCategory:

- Possui Nome
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)

Relacionamentos:

- 1:N com SubCategory
- Indiretamente relacionada a Product

Restrições:

- Nome deve ser único
- Não é permitido ativar categoria já ativa
- Não é permitido desativar categoria já inativa
- Deve existir antes da criação de SubCategories

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- MainCategory

Regras centrais:

- Nome é obrigatório
- Nome deve ser único
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateMainCategoryCommand
- UpdateMainCategoryCommand
- ActivateMainCategoryCommand
- DeactivateMainCategoryCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetMainCategoryByIdQuery
- GetAllMainCategoriesQuery
- GetMainCategoryDropdownQuery

Queries utilizam:

- Projeção direta (Select)
- Sem uso de Include desnecessário
- Paginação via ApplyPagination
- Queries somente leitura (AsNoTracking)

Retornam:

- Result<T>
- PagedResult<T>

---

#### Validators

- CreateMainCategoryCommandValidator
- UpdateMainCategoryCommandValidator
- ActivateMainCategoryCommandValidator
- DeactivateMainCategoryCommandValidator
- GetMainCategoryByIdQueryValidator
- GetAllMainCategoriesQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- MainCategoryResponse
- MainCategoryListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade MainCategory
- Mapeamento via Fluent API
- Persistência via EF Core
- Repository expõe IQueryable

Pontos importantes:

- Consultas otimizadas para SQL Server
- Uso de projeções para reduzir carga de dados
- Preparado para relacionamento com SubCategories

---

### 3.4 API

Controller:

- MainCategoriesController

Rotas:

- GET /api/v1/main-categories
- GET /api/v1/main-categories/dropdown
- GET /api/v1/main-categories/{id}
- POST /api/v1/main-categories
- PUT /api/v1/main-categories/{id}
- PATCH /api/v1/main-categories/{id}/activate
- PATCH /api/v1/main-categories/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- Nome da categoria deve ser único.
- Categoria não pode ser ativada se já estiver ativa.
- Categoria não pode ser desativada se já estiver inativa.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Não deve ser permitido desativar uma MainCategory que possua SubCategories ativas vinculadas.
- MainCategory deve existir antes da criação de SubCategory.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-06   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
