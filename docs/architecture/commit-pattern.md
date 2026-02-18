# Commit Pattern - ArarasHealthHub

Este projeto utiliza uma adaptação do padrão Conventional Commits.

---

## Estrutura

<tipo>(<módulo>): <descrição objetiva em português>

<corpo opcional explicando contexto, motivo e impacto>

---

## Regras Gerais

1. O escopo (<módulo>) é obrigatório.
2. A descrição deve estar obrigatoriamente em português.
3. Utilizar verbo no infinitivo.
4. Um commit deve representar uma única responsabilidade lógica.
5. Não misturar múltiplos módulos no mesmo commit.
6. Não utilizar descrições genéricas como:
   - ajuste
   - mudanças
   - update
   - melhorias
7. Refatorações estruturais devem conter corpo explicativo.
8. A linha de título deve ter no máximo 72 caracteres.
9. O corpo deve explicar o motivo da mudança, não apenas o que foi feito.
10. Não finalizar a descrição com ponto final.

---

## Tipos Permitidos

- feat → Nova funcionalidade
- fix → Correção de bug
- refactor → Refatoração sem alterar comportamento externo
- perf → Melhoria de performance
- docs → Alterações na documentação
- style → Formatação sem impacto funcional
- test → Adição ou ajuste de testes
- chore → Configuração, build, dependências
- security → Correção ou melhoria relacionada à segurança

---

## Estrutura Recomendada do Corpo

Utilizar lista de alterações quando necessário:

- Alteração 1
- Alteração 2
- Alteração 3

Opcionalmente adicionar bloco explicando motivação:

Objetivo:
Descrever o motivo arquitetural ou técnico da mudança.
