# Digital Innovation One - Prática .NET

## Bootcamp Take Blip

### Projeto Prático 2

API para cadastro e acesso de itens em um banco de dados com informações de jogos digitais. O foco deste projeto está na implementação de boas práticas de arquitetura.

Por se tratar de um projeto pedagógico, fez-se uso abundante de comentários, evidenciando detalhes, muitas vezes, já explícitos no código.

Será utilizada uma arquitetura em camadas do estilo Controller - Service - Repository.

Cada camada  é responsável por atribuições específicas, zelando, assim, pelo encapsulamento. As principais camadas de nosso código são as seguintes:
 - Controller: é a camada onde definimos as interações básicas entre o cliente e nossa API;
 - Service: é a parte do nosso código onde trabalhamos e mediamos informações entre a ponta do cliente e nosso repositório de informações;
 - Repository: essa camada cuida das operações de leitura e gravação de informações no nosso banco de dados;
 - Model: é a camada onde definimos nossos modelos de dados (nossos DTOs) e nossas entidades.
 
A presente API realizará as funcionalidades básicas de CRUD em nosso banco de dados e terá seus endpoints documentados no Swagger.

O presente projeto está dividio em 3 "branches":
 - Master: onde desenvolvemos o código da aplicação sem um vínculo com um SGBD específico (nela temos um dicionário em memória, fazendo as vezes de repositório, para fins de testes);
 - Postgres_Repository: Branch, derivada da master, vinculada com um repositório fazendo uso do sistema gerenciador de BD PostgreSQL;
 - SQL_Server_Repository: Branch, derivada da master, vinculada com um repositório fazendo uso do sistema gerenciador de BD SQL Server.

