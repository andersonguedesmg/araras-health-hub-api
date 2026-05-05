# Documentação da Feature: Facilities

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Facilities é responsável pelo gerenciamento completo de unidades do sistema.

Permite:

- Cadastro de unidade
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown
- Consulta de perfil completo da unidade (incluindo contas vinculadas)

---

## 2. Contexto de Domínio

Uma Facility:

- Possui Nome e CNES
- Possui Address (Value Object)
- Possui Contact (Value Object)
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)
- Possui múltiplas Accounts associadas

Restrições:

- CNES deve ser único
- Não é permitido ativar unidade já ativa
- Não é permitido desativar unidade já inativa

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Facility

Value Objects:

- Address
- Contact

Regras centrais:

- Nome é obrigatório
- CNES é obrigatório e único
- Address e Contact são obrigatórios
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateFacilityCommand
- UpdateFacilityCommand
- ActivateFacilityCommand
- DeactivateFacilityCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetFacilityByIdQuery
- GetAllFacilitiesQuery
- GetFacilityDropdownQuery
- GetFacilityProfileQuery

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

- CreateFacilityCommandValidator
- UpdateFacilityCommandValidator
- ActivateFacilityCommandValidator
- DeactivateFacilityCommandValidator
- GetFacilityByIdQueryValidator
- GetAllFacilitiesQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- FacilityResponse
- FacilityListItemResponse
- FacilityProfileResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade Facility via Fluent API
- Configuração de Address e Contact como owned types
- Persistência via EF Core
- Repository expõe IQueryable

Consultas otimizadas para SQL Server.

---

### 3.4 API

Controller:

- FacilitiesController

Rotas:

- GET /api/v1/facilities
- GET /api/v1/facilities/dropdown
- GET /api/v1/facilities/{id}
- GET /api/v1/facilities/profile
- POST /api/v1/facilities
- PUT /api/v1/facilities/{id}
- PATCH /api/v1/facilities/{id}/activate
- PATCH /api/v1/facilities/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporte a CancellationToken
- Declara ProducesResponseType para cenários relevantes

---

## 4. Regras de Negócio Específicas

- CNES deve ser único.
- Unidade não pode ser ativada se já estiver ativa.
- Unidade não pode ser desativada se já estiver inativa.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Uma Account sempre pertence a uma única Facility.
- O perfil da unidade deve retornar todas as Accounts vinculadas.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-04   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
