# Plano de Testes de Usabilidade


## Definição dos Objetivos

O objetivo deste plano é garantir que o sistema PRISMA — Sistema de Gestão de Chamados com Controle de SLA e Indicadores — seja intuitivo, funcional e atenda às necessidades dos diferentes perfis de usuário (Solicitante, Solucionador e Gestor), validando tanto aspectos técnicos quanto de experiência do usuário.

Entre os pontos principais estão:

- Verificar se os usuários conseguem concluir tarefas essenciais sem dificuldades, independentemente do perfil de acesso.
- Identificar barreiras na navegação e interação com o sistema, especialmente no fluxo de abertura e acompanhamento de chamados.
- Avaliar a eficiência e a satisfação do usuário ao utilizar a interface do PRISMA.
- Testar a clareza das informações exibidas nos dashboards e relatórios gerenciais.
- Avaliar a acessibilidade para diferentes perfis de familiaridade tecnológica.

---

## Seleção dos Participantes

**Critérios para seleção:**

- Colegas de faculdade com perfis variados, representando os diferentes usuários do sistema (solicitantes, analistas e gestores).
- Diferentes níveis de familiaridade com tecnologia (iniciante a avançado).
- Participantes sem conhecimento prévio do sistema PRISMA, para simular o primeiro acesso real.

**Quantidade recomendada:**

- Mínimo: 5 participantes.
- Ideal: entre 8 e 12 para maior diversidade de perfis e feedbacks.

**Distribuição sugerida por perfil:**

| Perfil Simulado | Quantidade Sugerida |
|:---:|:---:|
| Solicitante | 4 participantes |
| Solucionador | 3 participantes |
| Gestor | 3 participantes |

> **Observação:** Todos os dados coletados serão tratados de forma anônima, em conformidade com a LGPD (Lei Geral de Proteção de Dados), sem exposição de informações sensíveis ou pessoais dos participantes.

---

## Definição dos Cenários de Teste

### Cenário 1 – Cadastro de Usuário

| Item | Descrição |
|:---|:---|
| **Objetivo** | Avaliar a facilidade de criar uma conta no sistema PRISMA. |
| **Contexto** | Um novo colaborador da empresa precisa criar seu perfil de acesso ao sistema para registrar e acompanhar chamados. |
| **Perfil Testado** | Todos os perfis (Solicitante, Solucionador, Gestor) |
| **Tarefa** | Acessar a tela de cadastro, selecionar o perfil de acesso, preencher nome completo, e-mail, senha e empresa, e confirmar o cadastro. |
| **Critério de Sucesso** | Conta criada com sucesso, exibição da tela de confirmação e redirecionamento para a tela de Login. |

---

### Cenário 2 – Login no Sistema

| Item | Descrição |
|:---|:---|
| **Objetivo** | Avaliar a eficiência e clareza do processo de autenticação. |
| **Contexto** | O usuário já possui cadastro e deseja acessar o sistema para realizar suas atividades. |
| **Perfil Testado** | Todos os perfis (Solicitante, Solucionador, Gestor) |
| **Tarefa** | Selecionar o perfil de acesso, informar e-mail e senha cadastrados e clicar em "Entrar". |
| **Critério de Sucesso** | Usuário autenticado e redirecionado corretamente para o dashboard do perfil selecionado. Em caso de credenciais incorretas, exibição de mensagem de erro clara. |

---

### Cenário 3 – Abertura de Chamado

| Item | Descrição |
|:---|:---|
| **Objetivo** | Verificar se o Solicitante consegue registrar um chamado de forma rápida e intuitiva. |
| **Contexto** | Um colaborador precisa registrar formalmente uma solicitação de suporte ao setor de TI. |
| **Perfil Testado** | Solicitante |
| **Tarefa** | Acessar a tela de Novo Chamado, preencher título, descrição, categoria e prioridade, e enviar a solicitação. |
| **Critério de Sucesso** | Chamado registrado com sucesso, exibido na lista de Meus Chamados com status "Aberto". |

---

### Cenário 4 – Acompanhamento de Chamado

| Item | Descrição |
|:---|:---|
| **Objetivo** | Avaliar se o Solicitante consegue acompanhar o status e o histórico do seu chamado. |
| **Contexto** | O usuário deseja saber em que etapa está a resolução da sua solicitação e qual é o prazo estimado. |
| **Perfil Testado** | Solicitante |
| **Tarefa** | Acessar a lista de Meus Chamados, localizar um chamado aberto e visualizar seu status atual, prazo de SLA e histórico de interações. |
| **Critério de Sucesso** | Usuário consegue visualizar claramente o status, o prazo estimado (SLA) e o histórico do chamado sem necessidade de ajuda. |

---

### Cenário 5 – Atendimento de Chamado

| Item | Descrição |
|:---|:---|
| **Objetivo** | Verificar se o Solucionador consegue organizar sua fila de chamados e registrar o atendimento. |
| **Contexto** | Um analista precisa atender os chamados atribuídos a ele, respeitando a ordem de prioridade e os prazos de SLA. |
| **Perfil Testado** | Solucionador |
| **Tarefa** | Acessar a Fila de Chamados, identificar o chamado mais prioritário, atualizar seu status para "Em Atendimento" e registrar um comentário no histórico. |
| **Critério de Sucesso** | Status atualizado corretamente, comentário registrado no histórico do chamado e fila reorganizada conforme prioridade. |

---

### Cenário 6 – Cadastro de Processo

| Item | Descrição |
|:---|:---|
| **Objetivo** | Avaliar se o Gestor consegue cadastrar um processo institucional com etapas, responsáveis e prazos. |
| **Contexto** | O gestor precisa formalizar no sistema um processo interno da empresa, definindo as etapas e os responsáveis por cada uma. |
| **Perfil Testado** | Gestor |
| **Tarefa** | Acessar a tela de Gestão de Processos, clicar em "+ Novo", preencher o nome do processo, responsável geral, prazo e adicionar ao menos duas etapas com seus respectivos responsáveis e tempos previstos. Salvar o processo. |
| **Critério de Sucesso** | Processo cadastrado com sucesso, exibido na lista de Gestão de Processos com status "Em Andamento" e etapas corretamente registradas. |

---

### Cenário 7 – Gestão e Atualização de Processos

| Item | Descrição |
|:---|:---|
| **Objetivo** | Verificar se o Gestor consegue visualizar o panorama geral dos processos e atualizar o status de um processo. |
| **Contexto** | O gestor precisa monitorar o andamento dos processos da equipe e registrar a conclusão de um processo finalizado. |
| **Perfil Testado** | Gestor |
| **Tarefa** | Acessar a tela de Gestão de Processos, filtrar por status "Em Andamento", expandir as etapas de um processo, clicar em "Atualizar" e alterar o status para "Concluído". |
| **Critério de Sucesso** | Status do processo atualizado corretamente, refletido nos cards de resumo em tempo real e feedback visual exibido ao usuário. |

---

### Cenário 8 – Visualização de Relatórios e Indicadores

| Item | Descrição |
|:---|:---|
| **Objetivo** | Avaliar a clareza e utilidade dos dashboards e relatórios gerenciais. |
| **Contexto** | O gestor deseja analisar o desempenho da equipe e verificar o cumprimento de SLA no período. |
| **Perfil Testado** | Gestor |
| **Tarefa** | Acessar a tela de Relatórios, visualizar os indicadores gerais (total de chamados, resolvidos, em andamento, atrasados), verificar o percentual de cumprimento de SLA e aplicar o filtro por período (últimos 7 dias). |
| **Critério de Sucesso** | Indicadores exibidos corretamente, filtros funcionais e dados compreensíveis sem necessidade de explicação adicional. |

---

## Métodos de Coleta de Dados

Os dados coletados devem ajudar a entender a experiência dos usuários com o sistema PRISMA. Serão utilizados:

**Métricas quantitativas:**
- Tempo médio para concluir cada tarefa.
- Número de erros cometidos por tarefa.
- Taxa de sucesso por cenário.
- Número de cliques necessários para concluir cada fluxo.

**Métricas qualitativas:**
- Observação direta das dificuldades durante a execução das tarefas.
- Comentários espontâneos dos participantes durante o teste.

**Questionário pós-teste:**

Será aplicado o **SUS (System Usability Scale)**, composto por 10 afirmações avaliadas em escala de 1 a 5, gerando um score de 0 a 100. Complementarmente, serão feitas as seguintes perguntas qualitativas:

1. Qual foi a sua primeira impressão ao acessar o sistema PRISMA?
2. O que você achou mais fácil de realizar no sistema?
3. O que você achou mais difícil ou confuso?
4. As informações exibidas nos dashboards e relatórios foram claras para você?
5. O menu lateral facilitou sua navegação entre as telas?
6. Você sentiu falta de alguma funcionalidade durante o uso?
7. Que melhorias você sugeriria para o sistema?
8. Você recomendaria o sistema PRISMA para uso em uma empresa real?

---

## Critérios de Aceitação

As funcionalidades críticas do sistema devem atingir os seguintes índices mínimos para aprovação:

| Critério | Meta |
|:---|:---:|
| Taxa de sucesso nas tarefas essenciais (login, cadastro, abertura de chamado) | ≥ 90% |
| Score SUS (System Usability Scale) | ≥ 70 (bom) |
| Tempo médio para cadastrar um novo chamado | ≤ 2 minutos |
| Tempo médio para cadastrar um novo processo | ≤ 3 minutos |
| Tempo médio para realizar login | ≤ 1 minuto |
| Participantes que conseguiram navegar pelo menu lateral sem ajuda | ≥ 80% |

> **Referência de classificação do SUS:**
> - Abaixo de 50: inaceitável
> - Entre 50 e 70: razoável
> - Entre 70 e 85: bom
> - Acima de 85: excelente
