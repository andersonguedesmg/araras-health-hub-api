# Documentação da Feature: Accounts

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Accounts é responsável pelo gerenciamento de contas de usuários.

Permite:

- Criação de contas
- Atualização de dados
- Alteração de senha
- Ativação e desativação
- Consultar contas por ID, Facility ou listagem geral

A feature centraliza o controle de acesso administrativo.

---

## 2. Contexto de Domínio

Uma Account:

- Pertence obrigatoriamente a uma Facility
- Possui Role (nível funcional)
- Possui Scope (nível de acesso)
- Possui status de ativação via IsActive

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- ApplicationUser
- Facility

Enums:

- AccountRoleEnum
- AccountScopeEnum

Regras centrais:

- Role é imutável após criação
- Scope é imutável após criação
- Conta deve estar vinculada a uma Facility

---

### 3.2 Application

#### Commands

- CreateAccountCommand
- UpdateAccountCommand
- ChangePasswordCommand
- ActivateAccountCommand
- DeactivateAccountCommand

---

#### Queries

- GetAccountByIdQuery
- GetAccountsByFacilityQuery
- GetAllAccountsQuery

---

#### Validators

- CreateAccountValidator
- UpdateAccountValidator
- GetAllAccountsQueryValidator

---

#### Responses

- AccountResponse
- AccountListItemResponse
- FacilityResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade ApplicationUser
- Configuração de relacionamento com Facility
- Configuração de Owned Types (Address e Contact)
- Persistência via EF Core

---

### 3.4 API

Controller:

- AccountsController

Policies:

- Policy de gerenciamento de contas

Rotas:

- POST /accounts
- PUT /accounts/{id}
- GET /accounts/{id}
- GET /accounts
- PATCH /accounts/{id}/activate
- PATCH /accounts/{id}/deactivate

---

## 4. Regras de Negócio Específicas

- Toda conta deve estar vinculada a uma Facility.
- Role é imutável após criação.
- Scope é imutável após criação.
- Lockout não é utilizado.
- Controle de status é feito exclusivamente via IsActive.

---

## 10. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-02-18   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
