# Documentação da Feature: Receivings

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Receivings é responsável pelo gerenciamento completo das entradas de produtos no estoque.

Permite:

- Registro de recebimentos
- Entrada física de estoque
- Controle de lotes
- Atualização do custo médio ponderado
- Geração de movimentações de estoque
- Consulta por ID
- Listagem paginada

---

## 2. Contexto de Domínio

Um Receiving representa um documento de entrada de produtos no estoque.

Cada Receiving:

- Possui fornecedor responsável pela entrega
- Possui responsável pelo recebimento
- Possui conta responsável pela operação
- Possui data de recebimento
- Possui itens recebidos
- Atualiza o estoque consolidado
- Atualiza lotes do estoque
- Recalcula custo médio
- Gera movimentações de estoque

Relacionamentos:

- N:1 com Supplier
- N:1 com Employee
- N:1 com ApplicationUser
- 1:N com ReceivedItem

Cada ReceivedItem:

- Referencia um Product
- Possui lote
- Possui marca
- Possui validade
- Possui quantidade
- Possui valor unitário
- Possui valor total calculado

Restrições:

- Não é permitido recebimento sem itens
- Quantidade deve ser maior que zero
- Valor unitário não pode ser negativo
- Produto deve existir
- Funcionário responsável deve existir
- Fornecedor deve existir
- Data de validade deve ser futura
- Data de recebimento não pode ser futura

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Receiving
- ReceivedItem

Entidades relacionadas:

- Stock
- StockLot
- StockCost
- StockMovement

Regras centrais:

- Receiving deve possuir ao menos um item
- TotalValue é calculado dinamicamente
- ReceivedItem calcula TotalValue automaticamente
- Estoque consolidado deve ser atualizado
- Lotes devem ser atualizados
- CMP deve ser recalculado
- Movimentação de estoque deve ser registrada
- Operações inválidas geram DomainException ou DomainRuleException

---

### 3.2 Application

#### Commands

- CreateReceivingCommand

Result<int>.
O retorno representa o ID do recebimento criado.

---

#### Queries

- GetReceivingByIdQuery
- GetAllReceivingsQuery

Queries utilizam:

- AsNoTracking
- Projeção direta quando possível
- Paginação via PagedRequest/PagedResult
- Repository especializado para consultas detalhadas

Retornam:

- Result<ReceivingResponse>
- PagedResult<ReceivingListItemResponse>

---

#### Validators

- CreateReceivingCommandValidator
- CreateReceivedItemCommandValidator
- GetReceivingByIdQueryValidator
- GetAllReceivingsQueryValidator

Regras:

- Validam formato e consistência básica
- Não aplicam regra de negócio complexa
- Não executam lógica de estoque
- Não manipulam entidades

---

#### Responses

- ReceivingResponse
- ReceivingListItemResponse
- ReceivingItemResponse

Todos definidos como record e imutáveis.

#### Services

- InventoryEntryService
- IInventoryEntryService

Responsabilidades:

- Criar recebimento
- Atualizar estoque consolidado
- Atualizar lotes
- Recalcular CMP
- Registrar movimentações
- Centralizar regras transacionais de entrada

O serviço atua como orquestrador da entrada de estoque.

---

### 3.3 Infrastructure

- Uso de backing fields para coleções
- Uso de Fluent API
- Uso de Check Constraints
- Relacionamentos protegidos com DeleteBehavior.Restrict
- Consultas otimizadas com projeções
- Controle de integridade via FK

---

### 3.4 API

Controller:

- ReceivingsController

Rotas:

- GET /api/v1/receivings
- GET /api/v1/receivings/{id}
- POST /api/v1/receivings

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Protegido com Authorize

---

## 4. Regras de Negócio Específicas

- Recebimento deve possuir ao menos um item.
- Produto deve existir.
- Fornecedor deve existir.
- Funcionário responsável deve existir.
- Conta responsável deve existir.
- Quantidade deve ser maior que zero.
- Valor unitário não pode ser negativo.
- Data de validade deve ser futura.
- Data de recebimento não pode ser futura.
- Estoque consolidado deve ser atualizado automaticamente.
- Lotes devem ser criados ou incrementados automaticamente.
- CMP deve ser recalculado automaticamente.
- Toda entrada deve gerar movimentação de estoque.
- Total do recebimento é calculado dinamicamente.
- Total do item é calculado dinamicamente.
- Não deve existir estoque negativo.
- Não deve existir lote com saldo negativo.
- Recebimentos não devem executar exclusão física de movimentações históricas.
- Toda movimentação deve manter rastreabilidade documental.
- Movimentações devem registrar tipo, custo e responsável.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-14   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
