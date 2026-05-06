# Documentação da Feature: SubCategories

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature SubCategories é responsável pelo gerenciamento completo das subcategorias de produtos no sistema.

Permite:

- Cadastro de subcategoria
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Uma SubCategory:

- Possui Nome
- Está obrigatoriamente vinculada a uma MainCategory
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)

Relacionamentos:

N:1 com MainCategory
1:N com Product

Restrições:

- Nome deve ser único dentro da mesma MainCategory
- Não é permitido ativar subcategoria já ativa
- Não é permitido desativar subcategoria já inativa
- Não pode existir sem uma MainCategory válida

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- SubCategory

Regras centrais:

- Nome é obrigatório
- Deve estar associada a uma MainCategory válida
- Nome deve ser único dentro da mesma MainCategory
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateSubCategoryCommand
- UpdateSubCategoryCommand
- ActivateSubCategoryCommand
- DeactivateSubCategoryCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetSubCategoryByIdQuery
- GetAllSubCategoriesQuery
- GetSubCategoryDropdownQuery

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

- CreateSubCategoryCommandValidator
- UpdateSubCategoryCommandValidator
- ActivateSubCategoryCommandValidator
- DeactivateSubCategoryCommandValidator
- GetSubCategoryByIdQueryValidator
- GetAllSubCategoriesQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- SubCategoryResponse
- SubCategoryListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade SubCategory
- Mapeamento via Fluent API
- Persistência via EF Core
- Repository expõe IQueryable

Pontos importantes:

- Consultas otimizadas para SQL Server
- Uso de projeções para reduzir carga de dados
- Relacionamento configurado com MainCategory
- Integridade garantida via FK

---

### 3.4 API

Controller:

- SubCategoriesController

Rotas:

- GET /api/v1/sub-categories
- GET /api/v1/sub-categories/dropdown
- GET /api/v1/sub-categories/{id}
- POST /api/v1/sub-categories
- PUT /api/v1/sub-categories/{id}
- PATCH /api/v1/sub-categories/{id}/activate
- PATCH /api/v1/sub-categories/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- Nome da subcategoria deve ser único dentro da mesma MainCategory.
- Subcategoria não pode ser ativada se já estiver ativa.
- Subcategoria não pode ser desativada se já estiver inativa.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Subcategoria deve sempre estar vinculada a uma MainCategory válida.
- Não deve ser permitido desativar uma SubCategory que possua produtos ativos vinculados.
- Não deve ser permitido criar SubCategory para MainCategory inexistente ou inativa.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-06   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
