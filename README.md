# Digital Innovation One - Prática .NET

## Bootcamp Take Blip

### Projeto Prático 2

API para cadastro e acesso de itens em um banco de dados com informações de jogos digitais. O foco deste projeto está na implementação de boas práticas de arquitetura.

Por se tratar de um projeto pedagógico, fez-se uso abundante de comentários, evidenciando detalhes já explícitos no código.

Será utilizada uma arquitetura em camadas do estilo Controller - Service - Repository.

Cada camada  é responsável por atribuições específicas, zelando, assim, pelo encapsulamento. Dessa forma temos as seguintes camadas, em nosso código:
 - Controller: é a camada onde definimos as interações básicas entre o cliente e nossa API;
 - Service: é a parte do nosso código onde trabalhamos e mediamos informações entre a ponta do cliente e nosso repositório de informações;
 - Repository: essa camada cuida das operações de leitura e gravação de informações no nosso banco de dados.
 
A presente API realizará as funcionalidades básicas de CRUD em nosso banco de dados e terá seus endpoints documentados no Swagger.
 
