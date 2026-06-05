# Documentação da Feature: Orders

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Orders é responsável pelo gerenciamento completo do ciclo de solicitações internas de materiais e medicamentos.

Permite:

- Criação de pedidos
- Aprovação de pedidos
- Separação de pedidos
- Finalização de pedidos
- Cancelamento de pedidos
- Devolução de pedidos
- Consulta detalhada
- Listagem paginada
- Sugestão automática de lotes para separação utilizando FEFO

Impacto no sistema:

- Controla a saída de estoque
- Garante rastreabilidade dos produtos distribuídos
- Mantém integridade do saldo físico
- Gera movimentações de estoque
- Controla o fluxo operacional de distribuição

---

## 2. Contexto de Domínio

Uma Order representa uma solicitação de produtos realizada por uma unidade.

Cada Order:

- Possui unidade solicitante
- Possui colaborador solicitante
- Possui status
- Possui itens
- Pode ser aprovado
- Pode ser separado
- Pode ser finalizado
- Pode ser cancelado
- Pode originar devoluções

Relacionamentos:

- N:1 com Facility
- N:1 com Employee
- N:1 com OrderStatus
- 1:N com OrderItem
- 1:N com OrderSeparation
- 1:N com StockMovement

Cada OrderItem:

- Referencia um Product
- Possui quantidade solicitada
- Possui quantidade aprovada
- Participa do processo de separação

Durante a separação:

- Produtos são alocados em lotes
- Utiliza FEFO (First Expire First Out)
- O saldo disponível dos lotes é considerado
- A separação pode utilizar múltiplos lotes

Restrições:

- Pedido deve possuir ao menos um item
- Produto deve existir
- Unidade solicitante deve existir
- Funcionário solicitante deve existir
- Não é permitido aprovar pedido cancelado
- Não é permitido separar pedido não aprovado
- Não é permitido finalizar pedido não separado
- Não é permitido utilizar saldo inexistente

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Order
- OrderItem
- OrderStatus
- OrderSeparation

Entidades relacionadas:

- Product
- Stock
- StockLot
- StockMovement
- Facility
- Employee

Regras centrais:

- Pedido deve possuir itens válidos
- Fluxo de status deve ser respeitado
- Quantidade aprovada não pode ser negativa
- Quantidade separada não pode exceder quantidade aprovada
- Separação utiliza FEFO
- Estoque não pode ficar negativo
- Movimentações devem ser registradas
- Operações inválidas geram DomainException ou DomainRuleException

---

### 3.2 Application

#### Commands

- CreateOrderCommand
- ApproveOrderCommand
- SeparateOrderCommand
- FinalizeOrderCommand
- CancelOrderCommand
- CreateReturnOrderCommand

Result<int>.
O retorno representa o ID do recebimento criado.

---

#### Queries

- GetOrderByIdQuery
- GetAllOrdersQuery
- GetOrderPickingDetailsQuery

Queries utilizam:

- AsNoTracking
- Projeções diretas
- Paginação via PagedRequest/PagedResult
- Repositórios especializados

Retornam:

- Result<OrderResponse>
- Result<OrderPickingResponse>
- PagedResult<OrderListItemResponse>

---

#### Validators

- CreateOrderCommandValidator
- ApproveOrderCommandValidator
- SeparateOrderCommandValidator
- FinalizeOrderCommandValidator
- CancelOrderCommandValidator
- CreateReturnOrderCommandValidator
- GetOrderByIdQueryValidator
- GetAllOrdersQueryValidator
- GetOrderPickingDetailsQueryValidator

Regras:

- Validam formato e consistência básica
- Não aplicam regra de negócio complexa
- Não executam lógica de estoque
- Não manipulam entidades

---

#### Responses

- OrderResponse
- OrderListItemResponse
- OrderItemResponse
- OrderPickingResponse
- OrderItemPickingResponse
- OrderItemLotPickingResponse

Todos definidos como record e imutáveis.

---

#### Services

- IOrderCreationService
- OrderCreationService

Responsabilidades:

- Criar pedidos
- Validar produtos informados
- Validar unidade solicitante
- Construir agregados Order e OrderItem
- Persistir pedido inicial

- IOrderApprovalService
- OrderApprovalService

Responsabilidades:

- Aprovar pedidos
- Validar status atual
- Atualizar quantidades aprovadas
- Alterar status para aprovado
- Garantir integridade do fluxo operacional

- IOrderPickingService
- OrderPickingService

Responsabilidades:

Gerar sugestão de separação
Aplicar FEFO
Consolidar lotes disponíveis
Distribuir quantidades entre lotes
Centralizar regras de picking

O serviço atua apenas na montagem da proposta de separação.
Não realiza movimentação de estoque.

- IOrderSeparationService
- OrderSeparationService

Responsabilidades:

- Executar separação efetiva
- Validar disponibilidade de estoque
- Consumir lotes selecionados
- Atualizar saldos dos lotes
- Registrar movimentações de estoque
- Alterar status do pedido para separado

- IOrderFinalizationService
- OrderFinalizationService

Responsabilidades:

- Finalizar pedidos separados
- Confirmar saída definitiva dos produtos
- Registrar movimentações finais
- Atualizar status para finalizado
- Garantir consistência transacional

- IOrderCancellationService
- OrderCancellationService

Responsabilidades:

- Cancelar pedidos
- Validar possibilidade de cancelamento
- Registrar motivo do cancelamento
- Atualizar status do pedido
- Impedir novas operações sobre o pedido cancelado

- IOrderReturnService
- OrderReturnService

Responsabilidades:

- Processar devoluções
- Reintegrar estoque
- Atualizar lotes
- Registrar movimentações de entrada
- Manter rastreabilidade da devolução
- Criar vínculo com pedido original

Os serviços da feature Orders atuam como orquestradores dos casos de uso.

Eles concentram:

Regras de aplicação
Coordenação entre entidades
Integração com estoque
Atualização de lotes
Registro de movimentações
Controle do fluxo de status

Os handlers permanecem enxutos, delegando a execução da regra de negócio para os serviços especializados.

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

- OrdersController

Rotas:

- GET /api/v1/orders
- GET /api/v1/orders/{id}
- GET /api/v1/orders/{id}/picking
- POST /api/v1/orders
- POST /api/v1/orders/{id}/approve
- POST /api/v1/orders/{id}/separate
- POST /api/v1/orders/{id}/finalize
- POST /api/v1/orders/{id}/cancel
- POST /api/v1/orders/{id}/return

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para documentação Swagger

---

## 4. Regras de Negócio Específicas

- Pedido deve possuir ao menos um item.
- Produto deve existir.
- Unidade solicitante deve existir.
- Funcionário solicitante deve existir.
- Quantidade solicitada deve ser maior que zero.
- Quantidade aprovada não pode ser negativa.
- Pedido cancelado não pode ser aprovado.
- Pedido não aprovado não pode ser separado.
- Pedido não separado não pode ser finalizado.
- Quantidade separada não pode exceder quantidade aprovada.
- Separação deve utilizar FEFO.
- Apenas lotes com saldo disponível podem ser utilizados.
- Estoque não pode ficar negativo.
- Lotes não podem ficar negativos.
- Toda saída deve gerar movimentação de estoque.
- Toda devolução deve gerar movimentação de estoque.
- Movimentações devem manter rastreabilidade.
- Operações devem respeitar o fluxo de status definido.
- Usuários operacionais visualizam apenas pedidos da própria unidade.
- Sugestões de separação são calculadas dinamicamente no momento da consulta.
- A consulta de picking não altera saldo de estoque.
- A efetiva baixa de estoque ocorre apenas na separação/finalização.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-06-05   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
