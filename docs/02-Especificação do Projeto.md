# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

## Persona 1 – João Henrique
- **Idade:** 22 anos  
- **Profissão:** Estudante de Engenharia  
- **Localização:** Belo Horizonte, Brasil  
- **Formação:** Graduação em andamento  
- **Objetivo:** Criar uma rotina disciplinada para estudar e manter hábitos saudáveis.  

### Descrição
João é universitário, mora com os pais e tem dificuldade em manter uma rotina equilibrada entre estudos, lazer e saúde. Ele sente que perde muito tempo no celular e gostaria de criar disciplina para estudar regularmente, praticar exercícios e dormir mais cedo.  

### Dores
- Sente-se improdutivo e procrastina facilmente.  
- Não consegue manter consistência em novos hábitos (ex.: academia, leitura).  
- Fica frustrado por começar algo e abandonar após poucos dias.  

### Expectativas
- Ter um aplicativo que o lembre das metas diárias e registre seu progresso.  
- Conseguir visualizar sua evolução de forma clara e motivadora.  
- Se sentir motivado por recompensas ou feedback visual (ex.: streaks, conquistas).  

---

## Persona 2 – Maria Eduarda
- **Idade:** 28 anos  
- **Profissão:** Analista de Marketing  
- **Localização:** São Paulo, Brasil  
- **Formação:** Pós-graduação em andamento  
- **Objetivo:** Melhorar o autocuidado e manter hábitos de bem-estar no dia a dia.  

### Descrição
Maria tem uma rotina intensa de trabalho e estudos, e muitas vezes esquece de beber água, se alongar ou cuidar da saúde mental. Ela busca ferramentas que a ajudem a lembrar de pequenos hábitos de autocuidado, para não se sentir esgotada no final do dia.  

### Dores
- Esquece de se hidratar e de fazer pausas ao longo do dia.  
- Sente-se sobrecarregada e sem tempo para si mesma.  
- Já tentou usar listas de tarefas, mas não conseguiu manter a constância.  

### Expectativas
- Encontrar um app simples, prático e fácil de usar.  
- Ter lembretes automáticos para beber água, alongar e praticar mindfulness.  
- Manter uma rotina equilibrada que ajude no bem-estar físico e mental.  

---

## Persona 3 – Carlos Alberto
- **Idade:** 35 anos  
- **Profissão:** Programador  
- **Localização:** Curitiba, Brasil  
- **Formação:** Graduação em Ciência da Computação  
- **Objetivo:** Adquirir novos conhecimentos e organizar melhor sua rotina pessoal.  

### Descrição
Carlos é apaixonado por tecnologia, mas sente que sua rotina é dominada apenas pelo trabalho. Ele quer aprender coisas novas, como estudar inglês e ler mais livros, mas tem dificuldade em manter disciplina.  

### Dores
- Cria metas muito grandes e desanima rápido.  
- Não consegue visualizar sua evolução, então sente que não está progredindo.  
- Fica sobrecarregado quando tenta conciliar trabalho, família e novos hábitos.  

### Expectativas
- Ter flexibilidade para criar hábitos personalizados.  
- Receber lembretes inteligentes que não atrapalhem sua rotina.  
- Conseguir acompanhar seu progresso a longo prazo, de forma clara e motivadora.

---

## Persona 4 – Beatriz Lima
- **Idade:** 19 anos  
- **Profissão:** Estudante de Medicina  
- **Localização:** Recife, Brasil  
- **Formação:** Graduação em andamento  
- **Objetivo:** Equilibrar rotina intensa de estudos com saúde física e mental.  

### Descrição
Beatriz está no início da faculdade de Medicina e enfrenta uma rotina puxada de aulas, estudos e atividades extracurriculares. Ela sente dificuldade em manter hábitos básicos, como alimentação saudável e sono regulado, e gostaria de contar com uma ferramenta que a ajudasse a não se perder no meio da correria.  

### Dores
- Fica sobrecarregada com tantas tarefas e esquece de cuidar da saúde.  
- Tem dificuldade em organizar horários para estudo e descanso.  
- Já tentou usar planners físicos, mas não conseguiu manter a disciplina.  

### Expectativas
- Receber lembretes práticos para manter pequenos hábitos saudáveis.  
- Ter uma visão clara da sua rotina diária e semanal.  
- Sentir que está cuidando de si mesma, mesmo com a correria da faculdade.  

---

## Persona 5 – Rafael Monteiro
- **Idade:** 42 anos  
- **Profissão:** Gerente de Projetos  
- **Localização:** Porto Alegre, Brasil  
- **Formação:** MBA em Gestão de Projetos  
- **Objetivo:** Melhorar a produtividade e conciliar vida profissional e pessoal.  

### Descrição
Rafael tem uma carreira consolidada, mas sente que o estresse do trabalho afeta sua vida pessoal. Ele gostaria de desenvolver hábitos como praticar atividades físicas, passar mais tempo com a família e aprender a meditar, mas acaba sempre priorizando o trabalho.  

### Dores
- Sente que sua rotina é dominada por compromissos profissionais.  
- Tem dificuldade em manter consistência em atividades pessoais.  
- Sofre com estresse e falta de equilíbrio entre vida profissional e pessoal.  

### Expectativas
- Usar um app que o ajude a criar metas realistas e sustentáveis.  
- Acompanhar seu progresso para sentir que está evoluindo fora do trabalho.  
- Ter lembretes e estatísticas que incentivem a continuidade dos novos hábitos.  


## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
| Usuário | Criar uma conta           | Acessar meus hábitos em qualquer dispositivo               |
| Usuário       | Logar no sistema                 | Continuar acompanhando minhas metas já registradas |
| Usuário iniciante  | Ter uma lista de hábitos sugeridos (beber água, praticar exercícios, dormir cedo)           | Não começar do zero       |
| Usuário     | Receber lembretes periódicos dos hábitos | Não esquecer de praticá-los |
| Usuário | Cadastrar um novo hábito personalizado          | Que a aplicação se adapte às minhas metas pessoais               |
| Usuário       | Definir a frequência de um hábito (diária, semanal, mensal)                 | Acompanhar meu progresso corretamente |
| Usuário  | Receber notificações no celular/desktop           | Ser lembrado de cumprir meus hábitos       |
| Usuário     | Visualizar relatórios/gráficos de desempenho | Ver meu progresso ao longo do tempo |
| Usuário       | Marcar quando completei um hábito no dia                | Acompanhar meu histórico |
| Usuário  | Ver meu nível de consistência           | Manter a disciplina       |


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

| ID     | Descrição do Requisito                                                                              | Prioridade |
| ------ | --------------------------------------------------------------------------------------------------- | ---------- |
| RF-001 | A aplicação deve permitir **CRUD de Usuários**                                                      | ALTA       |
| RF-002 | A aplicação deve permitir **CRUD de Sessões/Autenticação** (login e logout)                         | ALTA       |
| RF-003 | A aplicação deve permitir **CRUD de Hábitos**                                                       | ALTA       |
| RF-004 | A aplicação deve permitir **CRUD de Check-ins de Hábito** (um por dia, com atualização se repetido) | ALTA       |
| RF-005 | A aplicação deve permitir **consultar métricas** (streak atual, streak máximo, adesão)              | MÉDIA      |
| RF-006 | A aplicação deve permitir **consultar visão geral (dashboard)** dos hábitos                         | MÉDIA      |


### Requisitos não Funcionais

| ID      | Descrição do Requisito                                                                               | Prioridade |
| ------- | ---------------------------------------------------------------------------------------------------- | ---------- |
| RNF-001 | A aplicação deve ser simples e intuitiva de usar                                                     | ALTA       |
| RNF-002 | A aplicação deve responder às ações do usuário em até 2 segundos                                     | MÉDIA      |
| RNF-003 | A aplicação deve salvar os dados dos usuários em banco de dados e recuperá-los de forma confiável    | ALTA       |
| RNF-004 | As senhas dos usuários não podem ser armazenadas em texto simples, devendo ser protegidas            | ALTA       |
| RNF-005 | O sistema deve suportar múltiplos usuários, garantindo que cada um acesse apenas seus próprios dados | ALTA       |
| RNF-006 | O sistema deve poder rodar em computadores pessoais e em serviços gratuitos de nuvem                 | MÉDIA      |
| RNF-007 | Os dados não devem ser perdidos após fechar ou reiniciar o sistema                                   | ALTA       |
| RNF-008 | O sistema deve ser compatível com navegadores e aplicativos que usem o back-end                      | MÉDIA      |

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID | Restrição                                                                 |
|----|---------------------------------------------------------------------------|
|01 | O projeto deverá ser entregue até o final do semestre                      |
|02 | O projeto não pode depender de serviços pagos obrigatórios                 |
|03 | O sistema deve ser executado localmente e em ambiente de nuvem gratuita 
|04 | Deve permitir que o usuário exclua sua conta e dados pessoais (LGPD)     |

## Diagrama de Casos de Uso

  O diagrama de casos de uso representa as principais interações do Usuário com o sistema Habit Tracker. Ele mostra como o usuário pode criar e gerenciar sua conta, definir metas, registrar e visualizar hábitos, além de acompanhar check-ins diários e conquistas de consistência. 
  As relações de associação indicam diretamente quais funcionalidades estão disponíveis ao ator principal.Além disso, o diagrama utiliza as relações <<include>> e <<extend>> para detalhar o comportamento do sistema. O include aparece quando um caso de uso depende obrigatoriamente de outro, como em Visualizar Check-in Diário, que sempre inclui Visualizar Progresso das Metas. Já o extend indica funções opcionais que podem complementar a experiência, como Configurar Lembretes ao definir metas, ou Compartilhar Conquistas ao visualizar conquistas de consistência. 

<img width="558" height="637" alt="Habitly drawio" src="https://github.com/user-attachments/assets/06ae7437-7777-474a-992e-31b13238436d" />

