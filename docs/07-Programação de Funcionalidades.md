# Programação de Funcionalidades (INCLUIR A PROGRAMAÇAÕ DE FUNCIONALIDADE EM PROFUNDIDADE)

| ID     | Descrição do Requisito                                                                               | Artefatos Produzidos                             | Aluno(a) Responsável |
| ------ | ---------------------------------------------------------------------------------------------------- | ------------------------------------------------ | -------------------- |
| RF-001 | A aplicação deve permitir **CRUD de Usuários**                                                       | Controller, View, Model de Usuários              | Sophia Calvano       |
| RF-002 | A aplicação deve permitir **CRUD de Sessões/Autenticação** (login e logout)                          | Controller de Login, View Login, Claims Identity | Sophia Calvano       |
| RF-003 | A aplicação deve permitir **CRUD de Hábitos**                                                        | Controller, View e Model de Hábitos              | —                    |
| RF-004 | A aplicação deve permitir **CRUD de Check-ins de Hábito** (um por dia, com atualização se repetido)  | Controller e Model de Checkins                   | —                    |
| RF-005 | A aplicação deve permitir **consultar métricas** (streak atual, streak máximo, adesão)               | Model de Métricas, View Dashboard                | —                    |
| RF-006 | A aplicação deve permitir **consultar visão geral (dashboard)** dos hábitos                          | View Dashboard, Controlador de Métricas          | —                    |
| RF-007 | A aplicação deve permitir **CRUD de Lembretes** associados aos hábitos                               | Controller e Model de Lembretes                  | —                    |
| RF-008 | A aplicação deve permitir **CRUD de Etiquetas (tags)** para organizar hábitos                        | Controller e Model de Tags                       | —                    |
| RF-009 | A aplicação deve permitir **definir periodicidade** dos hábitos (diário, dias fixos, X vezes/semana) | Model de Hábitos, Enum Periodicidade             | —                    |
| RF-010 | A aplicação deve permitir **arquivar hábitos**, preservando histórico de check-ins                   | Controller de Hábitos, Flag Arquivado            | —                    |
| RF-011 | A aplicação deve permitir **consultar histórico de check-ins** por hábito e por período de tempo     | View Histórico, Controller Checkins              | —                    |
| RF-012 | A aplicação deve registrar **conquistas de consistência** (ex.: 7, 30 e 100 dias)                    | Model de Métricas, Lógica de Conquistas          | —                    |
| RF-013 | A aplicação deve permitir **compartilhar conquistas** em redes sociais                               | Integração com redes sociais                     | —                    |
| RF-014 | A aplicação deve permitir **configuração de preferências do usuário**                                | Model de Preferências, View Configurações        | —                    |


# Instruções de acesso
Para acessar a aplicação Habitly com perfil de usuário padrão, siga as orientações abaixo:

🔗 Link de Acesso:

Credenciais de Acesso (Usuário):
Usuário: user00
Senha: 123456

Credenciais de Acesso (Administrador):
Usuário: admin00
Senha: 123456

Passos para Acesso:
1. Clique no link de acesso acima;
2. Na tela de login, insira o e-mail e senha de usuário;
3. Clique em “Entrar” para acessar o Habitly com perfil de usuário comum;
4. Você poderá criar, editar e acompanhar seus hábitos, mas não terá acesso às páginas administrativas.
