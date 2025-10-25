# Registro de Testes de Software

# Plano de teste - CT-01 – Criar Novo Usuário - 🎥 [Assista ao vídeo do CT-01](https://github.com/user-attachments/assets/a5262666-f6f9-40c7-aeac-a4e566ee5042)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/9b042204-0ccc-454e-9c83-07b39db08c05" />

|    **Registro de Teste**   |                         **CT-01 – Criar Novo Usuário**                        |
| :------------------------: | :---------------------------------------------------------------------------: |
|   **Requisito Associado**  |              RF-001 – A aplicação deve permitir CRUD de Usuários              |
|        **Objetivo**        |         Verificar se novos usuários podem ser cadastrados corretamente        |
| **Critérios de Aceitação** | Usuário deve ser criado com sucesso e os dados devem ser armazenados no banco |
|         **Método**         |                                Teste funcional                                |
|        **Resultado**       |      Usuário cadastrado com sucesso e redirecionado para a tela de login      |

# Plano de teste - CT-02 – Editar Dados de Usuário - 🎥 [Assista ao vídeo do CT-02](https://github.com/user-attachments/assets/6be5a998-4a46-451d-872a-7e8bd6632e10)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/0e2e2915-35c7-4ff4-a9b3-e060ebf387a4" />

|    **Registro de Teste**   |                  **CT-02 – Editar Dados de Usuário**                  |
| :------------------------: | :-------------------------------------------------------------------: |
|   **Requisito Associado**  |          RF-001 – A aplicação deve permitir CRUD de Usuários          |
|        **Objetivo**        |      Verificar se o sistema permite a edição de dados do usuário      |
| **Critérios de Aceitação** |    Alterações devem ser gravadas e exibidas corretamente no perfil    |
|         **Método**         |                            Teste funcional                            |
|        **Resultado**       | Dados atualizados corretamente e refletidos na visualização do perfil |


# Plano de teste - CT-03 – Excluir Usuário 🎥 [Assista ao vídeo do CT-03](https://github.com/user-attachments/assets/ce9b6bc7-64b1-4a05-90ef-89750a1a6b75)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/fbe7f6bd-62fc-4059-b0ff-b63d8b37a743" />

|    **Registro de Teste**   |                 **CT-03 – Excluir Usuário**                |
| :------------------------: | :--------------------------------------------------------: |
|   **Requisito Associado**  |     RF-001 – A aplicação deve permitir CRUD de Usuários    |
|        **Objetivo**        | Verificar se o sistema exclui usuários e remove seus dados |
| **Critérios de Aceitação** |    Conta deve ser excluída e removida do banco de dados    |
|         **Método**         |                       Teste funcional                      |
|        **Resultado**       |    Usuário excluído com sucesso, sem registros residuais   |


# Plano de teste - CT-04 – Login com Credenciais Válidas - 🎥 [Assista ao vídeo do CT-04](https://github.com/user-attachments/assets/db874989-adf3-4cf9-917e-bcd76ec35c74)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/708b351e-b361-4f32-b017-451777ca3826" />


|    **Registro de Teste**   |                   **CT-04 – Login com Credenciais Válidas**                  |
| :------------------------: | :--------------------------------------------------------------------------: |
|   **Requisito Associado**  |                     RF-002 – CRUD de Sessões/Autenticação                    |
|        **Objetivo**        | Verificar se os usuários conseguem acessar o sistema com credenciais válidas |
| **Critérios de Aceitação** |         Usuário deve ser autenticado e redirecionado para o dashboard        |
|         **Método**         |                                Teste funcional                               |
|        **Resultado**       |         Usuário autenticado com sucesso e redirecionado corretamente         |


# Plano de teste - CT-05 – Login com Senha Incorreta - 🎥 [Assista ao vídeo do CT-05](https://github.com/user-attachments/assets/4198f505-ec49-4784-a631-fbd784a6499f)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/b5a5a025-06c8-44e3-9cbb-fb515680064a" />

|    **Registro de Teste**   |           **CT-05 – Login com Senha Incorreta**          |
| :------------------------: | :------------------------------------------------------: |
|   **Requisito Associado**  |           RF-002 – CRUD de Sessões/Autenticação          |
|        **Objetivo**        | Verificar se o sistema impede acesso com senha incorreta |
| **Critérios de Aceitação** |    Deve ser exibida mensagem de erro e o acesso negado   |
|         **Método**         |                      Teste funcional                     |
|        **Resultado**       |   Mensagem de erro exibida corretamente, acesso negado   |


# Plano de teste - CT-06 – Logout - 🎥 [Assista ao vídeo do CT-06](https://github.com/user-attachments/assets/0cfcea7c-3c8d-4678-809a-2f04214316c3)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/00b80299-6cc1-4081-84d1-9ffc0656dcd9" />

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
