# Plano de Testes de Usabilidade

## Definição do(s) objetivo(s)

O objetivo é garantir que o sistema de gerenciamento de hábitos seja intuitivo, funcional e atenda às necessidades do usuário final, validando tanto aspectos técnicos (funcionalidades) quanto de experiência (usabilidade).  
Entre os pontos principais estão:  
- Verificar se os usuários conseguem concluir tarefas essenciais sem dificuldades.  
- Identificar barreiras na navegação e interação com o sistema.  
- Avaliar a eficiência e a satisfação do usuário ao utilizar a interface.  
- Testar a acessibilidade para diferentes perfis de usuários.  

## Seleção dos participantes

**Critérios para selecionar participantes:**  
- Perfis variados (estudantes, profissionais e adultos que buscam saúde e organização).  
- Diferentes níveis de familiaridade com tecnologia (iniciante a avançado).  
- Pessoas com necessidades especiais, se aplicável.  

**Quantidade recomendada:**  
- Mínimo: 5 participantes.  
- Ideal: entre 8 e 12 para maior diversidade.  

## Definição de cenários de teste

**Cenário 1 – Cadastro de Usuário**  
- **Objetivo:** Avaliar a facilidade de criar uma conta no sistema.  
- **Contexto:** Um novo usuário deseja utilizar a aplicação para organizar seus hábitos.  
- **Tarefa:** Preencher o formulário de cadastro com dados válidos e confirmar.  
- **Critério de Sucesso:** Conta criada com sucesso e redirecionamento para a tela inicial.  

**Cenário 2 – Login**  
- **Objetivo:** Avaliar a eficiência e clareza do processo de autenticação.  
- **Contexto:** O usuário já possui cadastro e deseja acessar seus hábitos.  
- **Tarefa:** Informar e-mail e senha válidos e efetuar login.  
- **Critério de Sucesso:** Usuário autenticado e acesso liberado à tela principal.  

**Cenário 3 – Criação de Hábito**  
- **Objetivo:** Verificar se o usuário consegue cadastrar um hábito de forma rápida e intuitiva.  
- **Contexto:** Usuário deseja acompanhar sua rotina de exercícios.  
- **Tarefa:** Inserir nome do hábito e definir meta de periodicidade.  
- **Critério de Sucesso:** Hábito cadastrado corretamente e exibido na lista.  

**Cenário 4 – Check-in Diário**  
- **Objetivo:** Avaliar se o usuário consegue registrar progresso em um hábito.  
- **Contexto:** Usuário deseja marcar que concluiu um hábito no dia.  
- **Tarefa:** Selecionar o hábito e marcar como concluído.  
- **Critério de Sucesso:** Hábito aparece como concluído e streak atualizado.  

**Cenário 5 – Visualização de Relatórios**  
- **Objetivo:** Avaliar a clareza na exibição de métricas de progresso.  
- **Contexto:** Usuário quer visualizar sua evolução semanal/mensal.  
- **Tarefa:** Acessar o painel de métricas.  
- **Critério de Sucesso:** Relatórios exibidos corretamente, com gráficos claros e dados consistentes.  

## Métodos de coleta de dados

Os dados coletados devem ajudar a entender a experiência dos usuários. Serão utilizados:  
- **Métricas quantitativas:** tempo médio para concluir cada tarefa, número de erros, taxa de sucesso.  
- **Métricas qualitativas:** observação de dificuldades, comentários espontâneos dos usuários.  
- **Questionários pós-teste:**  
  - SUS (System Usability Scale), para gerar um score de 0 a 100.  
  - Perguntas qualitativas, como:  
    - Qual foi a sua primeira impressão ao usar o sistema?  
    - O que você achou mais fácil de fazer?  
    - O que você achou mais difícil/confuso?  
    - Você se sentiu motivado a registrar hábitos diariamente?  
    - Que melhorias você sugeriria?  
    - Você recomendaria o sistema a colegas/amigos?  

**Observação:** Todos os dados serão coletados de forma anônima, em conformidade com a LGPD (Lei Geral de Proteção de Dados), sem exposição de informações sensíveis ou pessoais.  

## Cronograma

| Etapa | Duração | Responsável |
|-------|---------|-------------|
| Planejamento dos testes | 1 semana | Equipe de QA |
| Testes funcionais iniciais | 2 semanas | Dev + QA |
| Testes de usabilidade | 2 semanas | UX Researcher |
| Análise de resultados | 1 semana | Equipe de UX |
| Ajustes finais | 2 semanas | Equipe de Desenvolvimento |

## Critérios de Aceitação

- Funcionalidades críticas (cadastro, login, criação de hábito, check-ins) devem ter 100% de sucesso nos testes.  
- Métricas de usabilidade:  
  - **SUS ≥ 80** (considerado excelente).  
  - **Taxa de sucesso ≥ 90%** nas tarefas propostas.  
  - **Tempo médio para criar um hábito ≤ 1 minuto.**  
