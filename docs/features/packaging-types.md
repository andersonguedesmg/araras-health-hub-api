# Documentação da Feature: PackagingTypes

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature PackagingTypes é responsável pelo gerenciamento dos tipos de embalagem utilizados pelos produtos no sistema.

Permite:

- Cadastro de tipo de embalagem
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Um PackagingType:

- Possui Nome
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)

Relacionamentos:

1:N com Product

Restrições:

- Nome deve ser único
- Não é permitido ativar tipo de embalagem já ativo
- Não é permitido desativar tipo de embalagem já inativo

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- PackagingType

Regras centrais:

- Nome é obrigatório
- Nome deve ser único
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreatePackagingTypeCommand
- UpdatePackagingTypeCommand
- ActivatePackagingTypeCommand
- DeactivatePackagingTypeCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetPackagingTypeByIdQuery
- GetAllPackagingTypesQuery
- GetPackagingTypeDropdownQuery

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

- CreatePackagingTypeCommandValidator
- UpdatePackagingTypeCommandValidator
- ActivatePackagingTypeCommandValidator
- DeactivatePackagingTypeCommandValidator
- GetPackagingTypeByIdQueryValidator
- GetAllPackagingTypesQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- PackagingTypeResponse
- PackagingTypeListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade PackagingType
- Mapeamento via Fluent API
- Persistência via EF Core
- Repository expõe IQueryable

Pontos importantes:

- Consultas otimizadas para SQL Server
- Uso de projeções para reduzir carga de dados
- Integridade garantida via FK

---

### 3.4 API

Controller:

- PackagingTypesController

Rotas:

- GET /api/v1/packaging-types
- GET /api/v1/packaging-types/dropdown
- GET /api/v1/packaging-types/{id}
- POST /api/v1/packaging-types
- PUT /api/v1/packaging-types/{id}
- PATCH /api/v1/packaging-types/{id}/activate
- PATCH /api/v1/packaging-types/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- Nome do tipo de embalagem deve ser único.
- Tipo de embalagem não pode ser ativado se já estiver ativo.
- Tipo de embalagem não pode ser desativado se já estiver inativo.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Não deve ser permitido desativar um PackagingType que esteja sendo utilizado por produtos ativos.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-07   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
