# Plano de Testes de Software

| **Caso de Teste** | **CT-01 – Criar novo usuário** |
|:---:|:---:|
| Requisito Associado | RF-001 – CRUD de Usuários |
| Objetivo do Teste | Criar novo usuário |
| Passos | - Acessar tela de cadastro <br> - Preencher campos obrigatórios com dados válidos <br> - Clicar em "Cadastrar" |
| Critério de Êxito | Conta criada com sucesso e dados armazenados no banco |

| **Caso de Teste** | **CT-02 – Editar dados de usuário** |
| Requisito Associado | RF-001 – CRUD de Usuários |
| Objetivo do Teste | Editar dados de usuário |
| Passos | - Acessar tela de edição de perfil <br> - Alterar dados e salvar |
| Critério de Êxito | Alterações gravadas corretamente |

| **Caso de Teste** | **CT-03 – Excluir usuário** |
| Requisito Associado | RF-001 – CRUD de Usuários |
| Objetivo do Teste | Excluir usuário |
| Passos | - Acessar opção de excluir conta <br> - Confirmar exclusão |
| Critério de Êxito | Conta removida do sistema e dados apagados |

| **Caso de Teste** | **CT-04 – Login com credenciais válidas** |
| Requisito Associado | RF-002 – CRUD de Sessões/Autenticação |
| Objetivo do Teste | Login com credenciais válidas |
| Passos | - Acessar tela de login <br> - Informar e-mail e senha corretos <br> - Clicar em "Entrar" |
| Critério de Êxito | Usuário autenticado e redirecionado para o dashboard |

| **Caso de Teste** | **CT-05 – Login com senha incorreta** |
| Requisito Associado | RF-002 – CRUD de Sessões/Autenticação |
| Objetivo do Teste | Login com senha incorreta |
| Passos | - Acessar tela de login <br> - Informar e-mail válido e senha incorreta <br> - Clicar em "Entrar" |
| Critério de Êxito | Exibir mensagem de erro, acesso negado |

| **Caso de Teste** | **CT-06 – Logout** |
| Requisito Associado | RF-002 – CRUD de Sessões/Autenticação |
| Objetivo do Teste | Logout |
| Passos | - Clicar em "Sair" |
| Critério de Êxito | Sessão encerrada e usuário volta para tela de login |

| **Caso de Teste** | **CT-07 – Criar novo hábito com periodicidade** |
| Requisito Associado | RF-003 – CRUD de Hábitos |
| Objetivo do Teste | Criar novo hábito com periodicidade |
| Passos | - Acessar tela de criação de hábito <br> - Preencher nome, periodicidade e objetivo <br> - Salvar |
| Critério de Êxito | Hábito aparece na lista do usuário com os dados definidos |

| **Caso de Teste** | **CT-08 – Editar hábito existente** |
| Requisito Associado | RF-003 – CRUD de Hábitos |
| Objetivo do Teste | Editar hábito existente |
| Passos | - Selecionar hábito <br> - Alterar informações <br> - Salvar |
| Critério de Êxito | Alterações gravadas e exibidas na lista de hábitos |

| **Caso de Teste** | **CT-09 – Excluir hábito** |
| Requisito Associado | RF-003 – CRUD de Hábitos |
| Objetivo do Teste | Excluir hábito |
| Passos | - Selecionar hábito <br> - Clicar em "Excluir" <br> - Confirmar |
| Critério de Êxito | Hábito removido da lista e do banco |

| **Caso de Teste** | **CT-10 – Registrar check-in diário** |
| Requisito Associado | RF-004 – CRUD de Check-ins de Hábito |
| Objetivo do Teste | Registrar check-in diário |
| Passos | - Abrir hábito desejado <br> - Marcar check-in do dia |
| Critério de Êxito | Check-in registrado e streak atual atualizado |

| **Caso de Teste** | **CT-11 – Atualizar check-in já marcado** |
| Requisito Associado | RF-004 – CRUD de Check-ins de Hábito |
| Objetivo do Teste | Atualizar check-in já marcado |
| Passos | - Desmarcar ou remarcar check-in |
| Critério de Êxito | Check-in atualizado e streak recalculado corretamente |

| **Caso de Teste** | **CT-12 – Visualizar streak atual e máximo** |
| Requisito Associado | RF-005 – Consultar métricas |
| Objetivo do Teste | Visualizar streak atual e máximo |
| Passos | - Acessar dashboard de métricas |
| Critério de Êxito | Exibição correta de streak atual, streak máximo e taxa de adesão |

| **Caso de Teste** | **CT-13 – Visualizar hábitos cadastrados** |
| Requisito Associado | RF-006 – Consultar visão geral (dashboard) |
| Objetivo do Teste | Visualizar hábitos cadastrados |
| Passos | - Acessar dashboard geral |
| Critério de Êxito | Exibição de todos os hábitos com status de check-ins e métricas |

