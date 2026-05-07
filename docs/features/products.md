# Documentação da Feature: Products

> Esta documentação complementa o documento arquitetural central.

---

## 1. Objetivo

A feature Products é responsável pelo gerenciamento completo dos produtos no sistema.

Permite:

- Cadastro de produto
- Atualização de dados
- Ativação e desativação
- Consulta por ID
- Listagem paginada
- Listagem simplificada para dropdown

---

## 2. Contexto de Domínio

Um Product:

- Possui Nome e descrição
- Está vinculado a uma MainCategory
- Está vinculado a uma SubCategory
- Está vinculado a um PackagingType
- Possui status de ativação via IsActive
- Possui controle de auditoria (CreatedOn, UpdatedOn)


Relacionamentos:

N:1 com MainCategory
N:1 com SubCategory
N:1 com PackagingType

Restrições:

- Nome deve ser obrigatório
- MainCategory deve existir
- SubCategory deve existir
- PackagingType deve existir
- SubCategory deve pertencer à MainCategory informada
- Não é permitido ativar produto já ativo
- Não é permitido desativar produto já inativo

---

## 3. Estrutura

### 3.1 Domain

Entidades:

- Product

Regras centrais:

- Nome é obrigatório
- MainCategory é obrigatória
- SubCategory é obrigatória
- PackagingType é obrigatório
- SubCategory deve pertencer à MainCategory
- Controle de ativação via IsActive
- Datas de auditoria controladas pela aplicação

---

### 3.2 Application

#### Commands

- CreateProductCommand
- UpdateProductCommand
- ActivateProductCommand
- DeactivateProductCommand

Todos retornam Result ou Result<T>.

---

#### Queries

- GetProductByIdQuery
- GetAllProductsQuery
- GetProductDropdownQuery

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

- CreateProductCommandValidator
- UpdateProductCommandValidator
- ActivateProductCommandValidator
- DeactivateProductCommandValidator
- GetProductByIdQueryValidator
- GetAllProductsQueryValidator

Regras:

- Validam formato e consistência básica
- Não acessam banco
- Não aplicam regra de negócio
- Não verificam existência

---

#### Responses

- ProductResponse
- ProductListItemResponse
- DropdownItemResponse

Todos definidos como record e imutáveis.

---

### 3.3 Infrastructure

- Configuração da entidade Product
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

- ProductsController

Rotas:

- GET /api/v1/products
- GET /api/v1/products/dropdown
- GET /api/v1/products/{id}
- POST /api/v1/products
- PUT /api/v1/products/{id}
- PATCH /api/v1/products/{id}/activate
- PATCH /api/v1/products/{id}/deactivate

Regras:

- Utiliza BaseApiController
- Utiliza Send e SendCreated
- Suporta CancellationToken
- Declara ProducesResponseType para 400, 401, 403 e 404 quando aplicável

---

## 4. Regras de Negócio Específicas

- Nome do produto é obrigatório.
- MainCategory deve existir.
- SubCategory deve existir.
- PackagingType deve existir.
- SubCategory deve obrigatoriamente pertencer à MainCategory informada.
- Produto não pode ser ativado se já estiver ativo.
- Produto não pode ser desativado se já estiver inativo.
- Exclusão física não é permitida.
- Controle de status é feito exclusivamente via IsActive.
- Não deve ser permitido desativar produto com saldo em estoque ativo.
- Não deve ser permitido alterar categoria/subcategoria de produto que já possua movimentações.
- Todas as movimentações de estoque devem referenciar produtos válidos e ativos.
- Produto deve possuir PackagingType válido.
- Produtos inativos não devem aparecer em operações transacionais.

---

## 5. Histórico de Alterações

| Data         | Alteração                                                | Autor    |
| ------------ | -------------------------------------------------------- | -------- |
| 2026-05-07   | Refatoração completa seguindo diretrizes arquiteturais   | AG       |
| ------------ | -------------------------------------------------------- | -------- |
