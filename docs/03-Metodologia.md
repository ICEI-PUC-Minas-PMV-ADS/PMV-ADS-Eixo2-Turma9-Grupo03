
# Metodologia

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Documentação de Especificação</a></span>

A abordagem utilizada no desenvolvimento da API Habitly foi fundamentada no SCRUM, uma metodologia ágil que favorece entregas incrementais, ciclos curtos de trabalho e adaptação contínua aos requisitos do usuário. Essa escolha permite uma melhor organização da equipe, fragmentando tarefas em sprints e possibilitando maior eficiência no desenvolvimento.

No contexto do Habitly, o SCRUM é aplicado para garantir que as funcionalidades essenciais — como autenticação de usuários, criação e registro de hábitos, check-ins diários e lembretes — sejam entregues de forma progressiva, validadas a cada iteração e ajustadas de acordo com o feedback.

## Controle de Versão

A ferramenta de controle de versão adotada no projeto foi o
[Git](https://git-scm.com/), sendo que o [Github](https://github.com)
foi utilizado para hospedagem do repositório.

O projeto segue a seguinte convenção para o nome de branches:

- `main`: versão estável já testada do software
- `unstable`: versão já testada do software, porém instável
- `testing`: versão em testes do software
- `dev`: versão de desenvolvimento do software

Quanto à gerência de issues, o projeto adota a seguinte convenção para
etiquetas:

- `documentation`: melhorias ou acréscimos à documentação
- `bug`: uma funcionalidade encontra-se com problemas
- `enhancement`: uma funcionalidade precisa ser melhorada
- `feature`: uma nova funcionalidade precisa ser introduzida

## Gerenciamento de Projeto
O gerenciamento do projeto segue os princípios do SCRUM, utilizando o GitHub Projects em formato Kanban:

- Backlog: lista de todas as funcionalidades e requisitos levantados.
- To Do: tarefas planejadas para a sprint atual.
- In Progress: tarefas em andamento.
- Done: tarefas concluídas, testadas e integradas.

### Divisão de Papéis
- Scrum Master: Sophia
- Product Owner: Matheus
- Equipe de Desenvolvimento: Lucas, Pedro Henrique e Guilherme
- Equipe de Design: Júlia e Lorrayne

### Processo

As principais cerimônias aplicadas no Habitly são:
- Sprint Planning: definição do que será implementado em cada sprint, com divisão de tarefas.
- Daily Standup: reuniões semanais rápidas de acompanhamento do progresso e identificação de obstáculos.
- Sprint Review: apresentação das funcionalidades concluídas ao final de cada enterega. 
- Sprint Retrospective: reflexão sobre o que funcionou bem e o que pode ser melhorado na próxima sprint.

### Ferramentas
- GitHub: repositório de código e gestão de tarefas (Kanban).
- Visual Studio Code: ambiente principal de desenvolvimento da API.
- Figma: design de wireframes.
- Canva: criação de slides e materiais de apresentação.
- WhatsApp/Teams: comunicação da equipe e alinhamento rápido.
