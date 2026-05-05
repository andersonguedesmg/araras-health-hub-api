# Documentação da Feature: Suppliers

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Suppliers é responsável pelo gerenciamento completo de fornecedores do sistema.

Permite:

- Cadastro de fornecedor
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Um Supplier:

- Possui Nome, Razão Social, CNPJ
- Possui Address (Value Object)
- Possui Contact (Value Object)
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)

Restrições:

- CNPJ deve ser único
- Não é permitido ativar fornecedor já ativo
- Não é permitido desativar fornecedor já inativo

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Supplier

Regras centrais:

- CNPJ é obrigatório e único
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateSupplierCommand
- UpdateSupplierCommand
- ActivateSupplierCommand
- DeactivateSupplierCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetSupplierByIdQuery
- GetAllSuppliersQuery
- GetSupplierDropdownQuery

Queries utilizam:

- Projeção direta
- Paginação via ApplyPagination
- Sem uso de Include desnecessário
- Sem uso de ToLower em banco

Retornam:

- Result<T>
- PagedResult<T>

---

#### Validators

- CreateSupplierCommandValidator
- UpdateSupplierCommandValidator
- ActivateSupplierCommandValidator
- DeactivateSupplierCommandValidator
- GetSupplierByIdQueryValidator
- GetAllSuppliersQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- SupplierResponse
- SupplierListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade Supplier
- Mapeamento via Fluent API
- Persistência via EF Core
- Repository expõe IQueryable

Consultas otimizadas para SQL Server.

---

### 3.4 API

Controller:

- SuppliersController

Rotas:

- GET /api/v1/suppliers
- GET /api/v1/suppliers/dropdown
- GET /api/v1/suppliers/{id}
- POST /api/v1/suppliers
- PUT /api/v1/suppliers/{id}
- PATCH /api/v1/suppliers/{id}/activate
- PATCH /api/v1/suppliers/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- CNPJ deve ser único.
- Fornecedor não pode ser ativado se já estiver ativo.
- Fornecedor não pode ser desativado se já estiver inativo.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Fornecedor inativo não deve ser utilizado em novos processos de recebimento.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-05   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
