# Documentação da Feature: <NomeDaFeature>

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

Descrever claramente:

- O problema de negócio que a feature resolve
- Quem utiliza
- Qual impacto no sistema

---

## 2. Contexto de Domínio

Descrever:

- Entidades envolvidas
- Relacionamentos
- Restrições específicas
- Conceitos importantes

---

## 3. Estrutura

### 3.1 Domain

- Entidades:
- Enums:
- Value Objects:
- Regras de negócio centrais:

---

### 3.2 Application

#### Commands

- <CreateEntidade>Command
- <UpdateEntidade>Command

---

#### Queries

- <GetEntidade>Query
- <GetAllEntidade>Query

---

#### Validators

- <CreateEntidade>Validator
- <UpdateEntidade>Validator

---

#### Responses

<Entidade>Response
<Entidade>ListItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configurações de persistência
- Implementações de repositories
- Ajustes no DbContext

---

### 3.4 API

- Controller:
- Policies aplicadas:
- Rotas expostas:

---

## 4. Regras de Negócio Específicas

Listar todas as regras aplicadas.

Exemplo:

- Regra 1
- Regra 2
- Regra 3

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
|              |                                                          |          |
| ------------ | -------------------------------------------------------- | -------- |
