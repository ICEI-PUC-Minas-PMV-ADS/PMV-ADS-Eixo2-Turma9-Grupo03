# Registro de Testes de Software

Para cada caso de teste definido no Plano de Testes de Software, realize o registro das evidências dos testes feitos na aplicação pela equipe, que comprovem que o critério de êxito foi alcançado (ou não!!!). Para isso, utilize uma ferramenta de captura de tela que mostre cada um dos casos de teste definidos (obs.: cada caso de teste deverá possuir um vídeo do tipo _screencast_ para caracterizar uma evidência do referido caso).

|    **Registro de Teste**   |                         **CT-01 – Criar Novo Usuário**                        |
| :------------------------: | :---------------------------------------------------------------------------: |
|   **Requisito Associado**  |              RF-001 – A aplicação deve permitir CRUD de Usuários              |
|        **Objetivo**        |         Verificar se novos usuários podem ser cadastrados corretamente        |
| **Critérios de Aceitação** | Usuário deve ser criado com sucesso e os dados devem ser armazenados no banco |
|         **Método**         |                                Teste funcional                                |
|        **Resultado**       |      Usuário cadastrado com sucesso e redirecionado para a tela de login      |

Plano de teste - CT-01 – Criar Novo Usuário - 🎥 [Assista ao vídeo do CT-01](https://github.com/user-attachments/assets/3bad3b7f-6af5-46ff-b7e3-fc7276930f5b)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/ecb4c58e-acc8-4c8a-a27b-28b4f39d1be6"/>


|    **Registro de Teste**   |                  **CT-02 – Editar Dados de Usuário**                  |
| :------------------------: | :-------------------------------------------------------------------: |
|   **Requisito Associado**  |          RF-001 – A aplicação deve permitir CRUD de Usuários          |
|        **Objetivo**        |      Verificar se o sistema permite a edição de dados do usuário      |
| **Critérios de Aceitação** |    Alterações devem ser gravadas e exibidas corretamente no perfil    |
|         **Método**         |                            Teste funcional                            |
|        **Resultado**       | Dados atualizados corretamente e refletidos na visualização do perfil |

Plano de teste - CT-02 – Editar Dados de Usuário - 🎥 [Assista ao vídeo do CT-02](https://github.com/user-attachments/assets/b8e8565d-6b39-4c82-94ac-46ebd6a9200d)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/a61b0b13-bf39-4220-b5e9-4c2f1365684a" />


|    **Registro de Teste**   |                 **CT-03 – Excluir Usuário**                |
| :------------------------: | :--------------------------------------------------------: |
|   **Requisito Associado**  |     RF-001 – A aplicação deve permitir CRUD de Usuários    |
|        **Objetivo**        | Verificar se o sistema exclui usuários e remove seus dados |
| **Critérios de Aceitação** |    Conta deve ser excluída e removida do banco de dados    |
|         **Método**         |                       Teste funcional                      |
|        **Resultado**       |    Usuário excluído com sucesso, sem registros residuais   |

Plano de teste - CT-03 – Excluir Usuário 🎥 [Assista ao vídeo do CT-03](https://github.com/user-attachments/assets/54c02a11-ded5-435d-99fb-17bc77484644)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/d58f7031-a56b-4ab6-953d-c660c71f7e15" />


|    **Registro de Teste**   |                   **CT-04 – Login com Credenciais Válidas**                  |
| :------------------------: | :--------------------------------------------------------------------------: |
|   **Requisito Associado**  |                     RF-002 – CRUD de Sessões/Autenticação                    |
|        **Objetivo**        | Verificar se os usuários conseguem acessar o sistema com credenciais válidas |
| **Critérios de Aceitação** |         Usuário deve ser autenticado e redirecionado para o dashboard        |
|         **Método**         |                                Teste funcional                               |
|        **Resultado**       |         Usuário autenticado com sucesso e redirecionado corretamente         |

Plano de teste - CT-04 – Login com Credenciais Válidas - 🎥 [Assista ao vídeo do CT-04](https://github.com/user-attachments/assets/9a5a5806-1772-4797-8357-e02cd74287be)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/f2c016f9-f590-4f89-83db-da54384fe755" />


|    **Registro de Teste**   |           **CT-05 – Login com Senha Incorreta**          |
| :------------------------: | :------------------------------------------------------: |
|   **Requisito Associado**  |           RF-002 – CRUD de Sessões/Autenticação          |
|        **Objetivo**        | Verificar se o sistema impede acesso com senha incorreta |
| **Critérios de Aceitação** |    Deve ser exibida mensagem de erro e o acesso negado   |
|         **Método**         |                      Teste funcional                     |
|        **Resultado**       |   Mensagem de erro exibida corretamente, acesso negado   |

Plano de teste - CT-05 – Login com Senha Incorreta - 🎥 [Assista ao vídeo do CT-05](https://github.com/user-attachments/assets/f4d8bbdf-9cd0-46b7-9ca8-ad001c81af19)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/c5fad747-4af8-4211-9a12-04b2377d9cba" />


|    **Registro de Teste**   |                             **CT-06 – Logout**                            |
| :------------------------: | :-----------------------------------------------------------------------: |
|   **Requisito Associado**  |                   RF-002 – CRUD de Sessões/Autenticação                   |
|        **Objetivo**        |                Validar o encerramento da sessão de usuário                |
| **Critérios de Aceitação** | Sessão deve ser finalizada e o usuário redirecionado para a tela de login |
|         **Método**         |                              Teste funcional                              |
|        **Resultado**       |                        Logout realizado com sucesso         
Plano de teste - CT-06 – Logout - 🎥 [Assista ao vídeo do CT-06](https://github.com/user-attachments/assets/7299787b-f6ac-4364-bc18-5beaeb0e74a4)
<img width="2560" height="1528" alt="Image" src="https://github.com/user-attachments/assets/a803e30b-f43a-45fc-ae4b-e4aead896726" />


## Relatório de testes de software

Os testes de software realizados no sistema Habitly demonstram que as principais funcionalidades estão estáveis e em conformidade com os requisitos definidos.
O sistema permite o cadastro e autenticação de usuários, o gerenciamento completo de hábitos e check-ins diários, além da visualização de métricas de desempenho e histórico de progresso.
O dashboard apresenta corretamente as informações consolidadas de cada hábito, oferecendo uma visão clara da evolução do usuário.
Pequenos ajustes de layout e melhorias de usabilidade estão em andamento, com o objetivo de tornar a experiência mais fluida, moderna e acessível em diferentes dispositivos.
