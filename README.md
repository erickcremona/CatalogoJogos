# Desafio da DIO no Bootcamp Take Blip Fullstack Developer #2

### Criando um catálogo de jogos usando boas práticas de arquitetura com .NET

## DESCRIÇÃO:
#### Sua missão neste lab será construir uma arquitetura base para uma aplicação .net do zero.

##### OBS: 
- Nesta demo tentei colocar em prática tudo que venho aprendendo dentro e fora do bootcamp da DIO. O escopo do sistema é muito simples, mas em comparação à demo de exemplo do instrutor, acho que ficou bom.
- A persistência de dados da demo pode ser in memory ou configurando a ConnectionString no arquivo appsettings.json para utilizar SqlServer. Nas classes statup.cs e IdentityConfig.cs é possível perceber as configurações.
- O usuário que for cadastrado com o email: admin@teste.com e senha: Teste@123 terá todos os privilégios e ainda poderá fornecer privilégios aos outros usuários cadastrados.
- Está implementado o JWT para Autorização e Identity para autenticação. 
- Nesta demo foi utilizado também Swagger, AutoMapper, tentei utilizar o máximo que pude de SOLID, EntityFramework, exemplo de versionamento de api, exemplo de cors, Middleware para tratamento de StatusCode entre outros. 
