# Documentação da Feature: Employees

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Employees é responsável pelo gerenciamento completo de funcionários do sistema.

Permite:

- Cadastro de funcionário
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Um Employee:

- Possui Nome, CPF, Função, Telefone
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)

Restrições:

- CPF deve ser único
- Não é permitido ativar funcionário já ativo
- Não é permitido desativar funcionário já inativo

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Employee

Regras centrais:

- CPF é obrigatório
- Nome é obrigatório
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateEmployeeCommand
- UpdateEmployeeCommand
- ActivateEmployeeCommand
- DeactivateEmployeeCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetEmployeeByIdQuery
- GetAllEmployeesQuery
- GetEmployeeDropdownQuery

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

- CreateEmployeeCommandValidator
- UpdateEmployeeCommandValidator
- ActivateEmployeeCommandValidator
- DeactivateEmployeeCommandValidator
- GetEmployeeByIdQueryValidator
- GetAllEmployeesQueryValidator

Regras:

- Validators validam formato
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- EmployeeResponse
- EmployeeListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade Employee
- Mapeamento via Fluent API
- Persistência via EF Core
- Repository expõe IQueryable

Consultas otimizadas para SQL Server.

---

### 3.4 API

Controller:

- EmployeesController

Rotas:

- GET /api/v1/employees
- GET /api/v1/employees/dropdown
- GET /api/v1/employees/{id}
- POST /api/v1/employees
- PUT /api/v1/employees/{id}
- PATCH /api/v1/employees/{id}/activate
- PATCH /api/v1/employees/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- CPF deve ser único.
- Funcionário não pode ser ativado se já estiver ativo.
- Funcionário não pode ser desativado se já estiver inativo.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-02-26   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
