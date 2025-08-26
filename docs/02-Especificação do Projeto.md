# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas

Identifique, em torno de, 5 personas. Para cada persona, lembre-se de descrever suas angústicas, frustrações e expectativas de vida relacionadas ao problema. Além disso, defina uma "aparência" para a persona. Para isso, você poderá utilizar sites como [https://this-person-does-not-exist.com/pt#google_vignette](https://this-person-does-not-exist.com/pt) ou https://thispersondoesnotexist.com/ 

Utilize também como referência o exemplo abaixo:

<img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/IntApplicationProject-Template/blob/main/docs/img/AnaClara1.png" alt="Persona1"/>

Enumere e detalhe as personas da sua solução. Para tanto, baseie-se tanto nos documentos disponibilizados na disciplina e/ou nos seguintes links:

> **Links Úteis**:
> 
> - [Rock Content](https://rockcontent.com/blog/personas/)
> - [Hotmart](https://blog.hotmart.com/pt-br/como-criar-persona-negocio/)
> - [O que é persona?](https://resultadosdigitais.com.br/blog/persona-o-que-e/)
> - [Persona x Público-alvo](https://flammo.com.br/blog/persona-e-publico-alvo-qual-a-diferenca/)
> - [Mapa de Empatia](https://resultadosdigitais.com.br/blog/mapa-da-empatia/)
> - [Mapa de Stalkeholders](https://www.racecomunicacao.com.br/blog/como-fazer-o-mapeamento-de-stakeholders/)
>
Lembre-se que você deve ser enumerar e descrever precisamente e personalizada todos os clientes ideais que sua solução almeja.

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

|ID     | Descrição do Requisito                                                                 | Prioridade |
|-------|----------------------------------------------------------------------------------------|------------|
|RF-001 | A aplicação deve permitir que o usuário crie uma conta, faça login, logout e recupere senha | ALTA |
|RF-002 | A aplicação deve permitir que o usuário defina e edite seu perfil (nome e fuso horário) | MÉDIA |
|RF-003 | A aplicação deve permitir criar, visualizar, editar e excluir/arquivar hábitos          | ALTA |
|RF-004 | A aplicação deve permitir configurar a periodicidade/meta dos hábitos (diário, dias da semana ou X vezes por semana) | ALTA |
|RF-005 | A aplicação deve permitir registrar um check-in diário por hábito (um por dia, com atualização se repetido) | ALTA |
|RF-006 | A aplicação deve mostrar indicadores de progresso (streak atual, streak máximo e resumo semanal) | ALTA |
|RF-007 | A aplicação deve permitir organizar hábitos com etiquetas (tags) e buscar hábitos       | MÉDIA |
|RF-008 | A aplicação deve permitir configurar lembretes por hábito, escolhendo horário e dias da semana | ALTA |
|RF-009 | A aplicação deve registrar conquistas de consistência (ex.: 7, 30 e 100 dias)           | MÉDIA |
|RF-010 | A aplicação deve permitir compartilhar conquistas em redes sociais, sem expor dados pessoais | BAIXA |

### Requisitos não Funcionais

|ID      | Descrição do Requisito                                                               | Prioridade |
|--------|--------------------------------------------------------------------------------------|------------|
|RNF-001 | A aplicação deve ser simples e intuitiva de usar                                     | ALTA |
|RNF-002 | A aplicação deve responder às ações do usuário em até 2 segundos                     | MÉDIA |
|RNF-003 | A aplicação deve salvar os dados dos usuários em banco de dados e recuperá-los de forma confiável | ALTA |
|RNF-004 | As senhas dos usuários não podem ser armazenadas em texto simples, devendo ser protegidas | ALTA |
|RNF-005 | O sistema deve suportar múltiplos usuários, garantindo que cada um acesse apenas seus próprios dados | ALTA |
|RNF-006 | O sistema deve poder rodar em computadores pessoais e em serviços gratuitos de nuvem | MÉDIA |
|RNF-007 | Os dados não devem ser perdidos após fechar ou reiniciar o sistema                   | ALTA |
|RNF-008 | O sistema deve ser compatível com navegadores e aplicativos que usem o back-end      | MÉDIA |


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID | Restrição                                                                 |
|----|---------------------------------------------------------------------------|
|01 | O projeto deverá ser entregue até o final do semestre                      |
|02 | O projeto não pode depender de serviços pagos obrigatórios                 |
|03 | O MVP deve priorizar RF-001 a RF-008; conquistas e compartilhamento podem ser entregues depois |
|04 | O sistema deve ser executado localmente e em ambiente de nuvem gratuita    |
|05 | Deve permitir que o usuário exclua sua conta e dados pessoais (LGPD)       |

## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
