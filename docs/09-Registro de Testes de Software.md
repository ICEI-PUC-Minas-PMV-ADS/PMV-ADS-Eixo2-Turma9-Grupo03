# Registro de Testes de Software

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

|    **Registro de Teste**   |                         **CT-01 – Criar Novo Usuário**                        |
| :------------------------: | :---------------------------------------------------------------------------: |
|   **Requisito Associado**  |              RF-001 – A aplicação deve permitir CRUD de Usuários              |
|        **Objetivo**        |         Verificar se novos usuários podem ser cadastrados corretamente        |
| **Critérios de Aceitação** | Usuário deve ser criado com sucesso e os dados devem ser armazenados no banco |
|         **Método**         |                                Teste funcional                                |
|        **Resultado**       |      Usuário cadastrado com sucesso e redirecionado para a tela de login      |






|    **Registro de Teste**   |                  **CT-02 – Editar Dados de Usuário**                  |
| :------------------------: | :-------------------------------------------------------------------: |
|   **Requisito Associado**  |          RF-001 – A aplicação deve permitir CRUD de Usuários          |
|        **Objetivo**        |      Verificar se o sistema permite a edição de dados do usuário      |
| **Critérios de Aceitação** |    Alterações devem ser gravadas e exibidas corretamente no perfil    |
|         **Método**         |                            Teste funcional                            |
|        **Resultado**       | Dados atualizados corretamente e refletidos na visualização do perfil |






|    **Registro de Teste**   |                   **CT-04 – Login com Credenciais Válidas**                  |
| :------------------------: | :--------------------------------------------------------------------------: |
|   **Requisito Associado**  |                     RF-002 – CRUD de Sessões/Autenticação                    |
|        **Objetivo**        | Verificar se os usuários conseguem acessar o sistema com credenciais válidas |
| **Critérios de Aceitação** |         Usuário deve ser autenticado e redirecionado para o dashboard        |
|         **Método**         |                                Teste funcional                               |
|        **Resultado**       |         Usuário autenticado com sucesso e redirecionado corretamente         |






|    **Registro de Teste**   |           **CT-05 – Login com Senha Incorreta**          |
| :------------------------: | :------------------------------------------------------: |
|   **Requisito Associado**  |           RF-002 – CRUD de Sessões/Autenticação          |
|        **Objetivo**        | Verificar se o sistema impede acesso com senha incorreta |
| **Critérios de Aceitação** |    Deve ser exibida mensagem de erro e o acesso negado   |
|         **Método**         |                      Teste funcional                     |
|        **Resultado**       |   Mensagem de erro exibida corretamente, acesso negado   |





|    **Registro de Teste**   |                             **CT-06 – Logout**                            |
| :------------------------: | :-----------------------------------------------------------------------: |
|   **Requisito Associado**  |                   RF-002 – CRUD de Sessões/Autenticação                   |
|        **Objetivo**        |                Validar o encerramento da sessão de usuário                |
| **Critérios de Aceitação** | Sessão deve ser finalizada e o usuário redirecionado para a tela de login |
|         **Método**         |                              Teste funcional                              |
|        **Resultado**       |                        Logout realizado com sucesso         






## Relatório de testes de software

Os testes de software realizados no sistema Habitly demonstram que as principais funcionalidades estão estáveis e em conformidade com os requisitos definidos.
O sistema permite o cadastro e autenticação de usuários, o gerenciamento completo de hábitos e check-ins diários, além da visualização de métricas de desempenho e histórico de progresso.
O dashboard apresenta corretamente as informações consolidadas de cada hábito, oferecendo uma visão clara da evolução do usuário.
Pequenos ajustes de layout e melhorias de usabilidade estão em andamento, com o objetivo de tornar a experiência mais fluida, moderna e acessível em diferentes dispositivos.
