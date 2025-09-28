
# Projeto de Interface

<img width="785" height="570" alt="Image" src="https://github.com/user-attachments/assets/ee5c6914-68fd-40b6-96be-9195592aa888" />

Esta é a tela inicial do Habitly. Ela funciona como a landing page do sistema, apresentando o nome do aplicativo, um texto de boas-vindas e os botões de Login e Cadastro. Seu objetivo é direcionar novos usuários para a criação de conta e permitir que usuários já registrados acessem o sistema. Os requisitos funcionais atendidos aqui são o RF-001 (CRUD de Usuários) e RF-002 (Autenticação).

<img width="796" height="572" alt="Image" src="https://github.com/user-attachments/assets/77c36512-0240-4beb-94a8-41101c5c194f" />

A tela de cadastro permite que novos usuários criem sua conta informando nome, e-mail e senha. Ela garante a persistência dos dados no sistema e atende ao requisito funcional RF-001. Essa tela é importante para personas como João e Maria, que estão iniciando o uso da plataforma e precisam começar a registrar seus hábitos.

<img width="783" height="574" alt="Image" src="https://github.com/user-attachments/assets/69911efe-7ba1-4488-8503-19828331e6d6" />

A tela de login possibilita que usuários previamente cadastrados acessem o sistema. Ela solicita e-mail e senha, além de oferecer a opção de recuperação de credenciais esquecidas. Esta interface cobre o requisito funcional RF-002, relacionado à autenticação e gestão de sessões. É especialmente útil para usuários como Rafael e Carlos, que precisam manter o acesso contínuo às suas metas.

<img width="785" height="559" alt="Image" src="https://github.com/user-attachments/assets/2ed52b6f-03a0-4f3d-af61-72884998d8a2" />

Na tela de confirmação de e-mail, o usuário insere o endereço cadastrado para validar a conta ou iniciar o processo de recuperação de senha. Este fluxo garante segurança e confiabilidade ao acesso, atendendo ao RF-002 e ao requisito não funcional RNF-004, que trata da proteção das senhas.

<img width="789" height="566" alt="Image" src="https://github.com/user-attachments/assets/c8eed021-9f63-4fb6-bfab-2a836196b712" />

A tela de cadastro de nova senha aparece após a confirmação do e-mail. Ela permite redefinir a credencial de acesso com segurança. Esse processo assegura que os dados do usuário estejam protegidos, cobrindo novamente o RF-002 e o RNF-004.

<img width="791" height="571" alt="Image" src="https://github.com/user-attachments/assets/1c22fad2-ba28-4abe-bb3c-659ff4a67316" />

O dashboard principal apresenta a lista de hábitos e tarefas. O usuário pode marcar check-ins, visualizar níveis de urgência e adicionar novos itens por meio do botão de inclusão. Esta tela concentra vários requisitos funcionais: RF-003 (CRUD de Hábitos), RF-004 (Check-in), RF-006 (visão geral), e RF-009 (periodicidade). Ela atende a personas como Beatriz, que precisam acompanhar sua rotina de forma clara.

<img width="784" height="569" alt="Image" src="https://github.com/user-attachments/assets/bfeef1ac-080a-4c5c-a256-78fbbf3f7229" />

A tela de configurações voltada para lembretes e notificações permite ativar alertas relacionados a hábitos saudáveis e tarefas urgentes. Aqui são atendidos o RF-007 (CRUD de Lembretes) e o RF-014 (preferências do usuário). Essa funcionalidade é especialmente relevante para Maria, que precisa de lembretes constantes para manter seus hábitos de autocuidado.

<img width="787" height="562" alt="Image" src="https://github.com/user-attachments/assets/3427ae58-3211-46c0-9171-d5353f438d39" />

Por fim, a tela de configurações de dados pessoais possibilita ao usuário alterar informações sensíveis, como e-mail e senha. Ela cobre o RF-014 e o RNF-003, que trata da persistência de dados. É voltada para personas como Rafael, que precisam manter segurança e flexibilidade no acesso ao sistema.

[Acesse o protótipo no Figma](https://www.figma.com/proto/USbcuDcQYtTyBcDu3Wh0B7/Habitly?node-id=9-154&t=oW5ihTMJGirI2Kww-1&scaling=scale-down&content-scaling=fixed&page-id=0%3A1&starting-point-node-id=10%3A13)

## Diagrama de Fluxo

O diagrama apresenta o estudo do fluxo de interação do usuário com o sistema interativo e  muitas vezes sem a necessidade do desenho do design das telas da interface. Isso permite que o design das interações seja bem planejado e gere impacto na qualidade no design do wireframe interativo que será desenvolvido logo em seguida.

O diagrama de fluxo pode ser desenvolvido com “boxes” que possuem internamente a indicação dos principais elementos de interface - tais como menus e acessos - e funcionalidades, tais como editar, pesquisar, filtrar, configurar - e a conexão entre esses boxes a partir do processo de interação. Você pode ver mais explicações e exemplos https://www.lucidchart.com/blog/how-to-make-a-user-flow-diagram.

![Exemplo de Diagrama de Fluxo](img/diagramafluxo2.jpg)

As referências abaixo irão auxiliá-lo na geração do artefato “Diagramas de Fluxo”.

> **Links Úteis**:
> - [Fluxograma online: seis sites para fazer gráfico sem instalar nada | Produtividade | TechTudo](https://www.techtudo.com.br/listas/2019/03/fluxograma-online-seis-sites-para-fazer-grafico-sem-instalar-nada.ghtml)

## Diagrama de Fluxo

![WhatsApp Image 2025-09-24 at 22 25 56](https://github.com/user-attachments/assets/275a3c7d-7d03-4017-852b-35cc2adb34c1)

<br>

## Wireframes

![Exemplo de Wireframe](img/wireframe-example.png)

Os wireframes são protótipos utilizados no design de interfaces para representar a estrutura de um site e o relacionamento entre suas páginas. Eles funcionam como ilustrações do layout e da disposição dos elementos essenciais da interface.

Nesta seção, é FUNDAMENTAL indicar, para cada tela/wireframe proposto, quais requisitos do projeto estão sendo contemplados por aquela tela.
 
> **Links Úteis**:
> - [Protótipos vs Wireframes](https://www.nngroup.com/videos/prototypes-vs-wireframes-ux-projects/)
> - [Ferramentas de Wireframes](https://rockcontent.com/blog/wireframes/)
> - [MarvelApp](https://marvelapp.com/developers/documentation/tutorials/)
> - [Figma](https://www.figma.com/)
> - [Adobe XD](https://www.adobe.com/br/products/xd.html#scroll)
> - [Axure](https://www.axure.com/edu) (Licença Educacional)
> - [InvisionApp](https://www.invisionapp.com/) (Licença Educacional)
