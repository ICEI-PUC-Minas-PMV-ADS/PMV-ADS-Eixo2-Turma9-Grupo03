# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

## Diagrama de Classes


<img width="852" height="672" alt="diagrama de classes" src="https://github.com/user-attachments/assets/28956b4d-e29e-4daf-a1ba-c4adcf7a5045" />


## Modelo ER (Projeto Conceitual)

O modelo foi pensado a partir do usuário como entidade central, responsável por criar e gerenciar seus hábitos, realizar check-ins para registrar a execução diária e receber notificações de apoio. Cada hábito pode ter lembretes associados, para estimular a constância, e metas estabelecidas, que quantificam os objetivos a serem alcançados. As métricas permitem acompanhar a evolução do usuário, registrando sequências atuais e máximas de hábitos realizados, enquanto as conquistas funcionam como recompensas ou marcos atingidos, fortalecendo a gamificação do sistema e incentivando o engajamento contínuo.

<img width="751" height="581" alt="MER Conceitual drawio" src="https://github.com/user-attachments/assets/b37f2e58-b7b2-43c3-970f-9451f19d4ebc" />


## Projeto da Base de Dados

<img width="1389" height="831" alt="Image" src="https://github.com/user-attachments/assets/9c6b1c3f-ed41-42a9-86d0-3a9d7cc26279" />


## Tecnologias Utilizadas
Tecnologias Utilizadas
HTML e CSS - Utilizados para a estrutura e estilo das páginas web.
JavaScript - Para interatividade do site e funcionalidades dinâmicas
C# – Linguagem usada para programar a API.
ASP.NET Core – Framework para criar os endpoints e organizar as rotas da aplicação.
Entity Framework Core – Para facilitar a comunicação do C# com o SQLServer.
SQLServer – Banco de dados.
Visual Studio – Ambiente de desenvolvimento usado para programar e rodar o projeto.
Git e GitHub – Controle de versão e local de armazenamento do código.
Figma/Canvas - Wireframes e desgin.

<img width="3840" height="1368" alt="Image" src="https://github.com/user-attachments/assets/da858596-d0ac-41b5-b537-eff07f6ab880" />

## Hospedagem

O Habitly foi hospedado na Microsoft Azure, usando um App Service integrado ao GitHub para facilitar a atualização do sistema. Essa escolha garante que a aplicação em ASP.NET Core com banco de dados SQL Server funcione de forma segura, estável e acessível. Assim, os usuários conseguem acessar a plataforma pelo navegador sem precisar de instalação local, com boa disponibilidade e praticidade.


