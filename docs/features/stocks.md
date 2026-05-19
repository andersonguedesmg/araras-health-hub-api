# Documentação da Feature: Stocks

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Stocks é responsável pelo gerenciamento consolidado do estoque do sistema.

Permite:

- Controle de saldo consolidado
- Controle de lotes
- Controle de estoque reservado
- Controle de estoque mínimo
- Ajustes de estoque
- Consulta de saldos
- Consulta de lotes ativos
- Consulta de produtos críticos
- Consulta de lotes próximos ao vencimento
- Rastreabilidade operacional
- Controle de custo médio ponderado

---

## 2. Contexto de Domínio

Cada Stock:

- Representa o estoque consolidado de um Product
- Possui quantidade atual
- Possui quantidade reservada
- Possui quantidade mínima
- Possui custo médio
- Possui múltiplos lotes

Cada StockLot:

- Representa um lote físico do produto
- Possui validade
- Possui marca
- Possui saldo disponível
- Possui vínculo opcional com ReceivedItem

Relacionamentos:

- 1:1 com Product
- 1:N com StockLot
- 1:1 com StockCost
- 1:N com StockMovement

Conceitos importantes:

- CurrentQuantity representa saldo físico total
- ReservedQuantity representa saldo reservado
- AvailableQuantity é calculado dinamicamente
- Estoque crítico ocorre quando AvailableQuantity <= MinQuantity
- Estoque disponível nunca pode ser negativo
- Lotes nunca podem possuir saldo negativo

Restrições:

- Produto deve existir
- Quantidades não podem ser negativas
- Reserva não pode ultrapassar saldo disponível
- Baixa não pode ultrapassar saldo disponível
- Lote deve possuir saldo positivo para movimentação
- Quantidade mínima não pode ser negativa

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Stock
- StockLot
- StockCost
- StockMovement
- StockAdjustment

Enums

- StockOperationTypeEnum
- StockMovementTypeEnum
- StockAdjustmentTypeEnum

Regras centrais:

- Estoque consolidado não pode ficar negativo
- Estoque reservado não pode ficar negativo
- Lotes não podem possuir saldo negativo
- Quantidade mínima não pode ser negativa
- Operações inválidas geram DomainException
- Violações de consistência geram DomainRuleException
- AvailableQuantity é calculado dinamicamente
- Toda movimentação deve ser rastreável

---

### 3.2 Application

#### Commands

- CreateStockAdjustmentCommand
- SetMinimumStockLevelCommand

Result<int>.
Result.

---

#### Queries

##### Estoque consolidado

- GetStocksQuery
- GetStockByProductIdQuery
- GetCriticalStocksQuery

##### Lotes

- GetAvailableStockLotsQuery
- GetStockLotsNearExpiryQuery

##### Ajustes

- GetAllStockAdjustmentsQuery
- GetStockAdjustmentByIdQuery

##### Quantidade mínima

- GetAllMinimumStockLevelsQuery

Queries utilizam:

- AsNoTracking
- Projeção otimizada
- Paginação via PagedRequest/PagedResult
- CancellationToken

Retornam:

- Result<>
- PagedResult<>

---

#### Validators

- CreateStockAdjustmentCommandValidator
- SetMinimumStockLevelCommandValidator
- GetStocksQueryValidator
- GetCriticalStocksQueryValidator
- GetAvailableStockLotsQueryValidator
- GetStockLotsNearExpiryQueryValidator
- GetStockByProductIdQueryValidator
- GetAllStockAdjustmentsQueryValidator
- GetStockAdjustmentByIdQueryValidator
- GetAllMinimumStockLevelsQueryValidator

Regras:

- Validam formato e consistência básica
- Não aplicam regra de negócio complexa
- Não executam lógica de estoque
- Não manipulam entidades

---

#### Responses

##### Estoque

- StockResponse
- StockListItemResponse
- CriticalStockListItemResponse
- MinimumStockLevelListItemResponse

##### Lotes

- AvailableStockLotListItemResponse
- StockLotNearExpiryListItemResponse

##### Ajustes

- StockAdjustmentResponse
- StockAdjustmentListItemResponse

Todos definidos como record e imutáveis.

#### Services

- InventoryEntryService

Responsabilidades:

- Atualizar estoque consolidado
- Atualizar lotes
- Recalcular custo médio
- Registrar movimentações
- Centralizar entrada de estoque

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

- StocksController

Rotas:

##### Ajustes

- POST /api/v1/stocks/adjustments
- GET /api/v1/stocks/adjustments
- GET /api/v1/stocks/adjustments/{id}

##### Estoque consolidado

- GET /api/v1/stocks
- GET /api/v1/stocks/product/{productId}
- GET /api/v1/stocks/critical

##### Lotes

- GET /api/v1/stocks/lots/available
- GET /api/v1/stocks/lots/near-expiry

##### Quantidade mínima

- PATCH /api/v1/stocks/minimum-stock-level
- GET /api/v1/stocks/minimum-stock-levels

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- Estoque não pode ficar negativo.
- Estoque reservado não pode ficar negativo.
- Reserva não pode ultrapassar saldo disponível.
- Quantidade mínima não pode ser negativa.
- Lotes devem possuir quantidade positiva.
- Lotes não podem possuir saldo negativo.
- Estoque crítico ocorre quando AvailableQuantity <= MinQuantity.
- Produtos próximos ao vencimento devem considerar limite configurável.
- AvailableQuantity deve ser calculado dinamicamente.
- Ajustes devem gerar movimentações rastreáveis.
- Movimentações devem registrar tipo e responsável.
- Custo médio deve ser recalculado após entradas.
- Estoque consolidado deve refletir soma operacional válida.
- Operações inválidas devem lançar exceções de domínio.
- Queries devem utilizar consultas otimizadas.
- Consultas de listagem devem suportar paginação.
- Consultas de listagem devem suportar ordenação.
- Consultas devem utilizar AsNoTracking quando apropriado.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-19   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
