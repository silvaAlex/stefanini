# Stefanini

## Descrisção do projeto

### Funcionalides
 - Gerenciamento de Pedidos: Permiti a criação, leitura, atualização e exclusão de pedidos.

### Tecnologias Utilizadas
 - API REST
    - ASP.NET Core
    - Entity Framework Core
    - Swagger (para documentação da API)

### Como rodar aplicação

é necessario ter o dotnet ef tools instalado na máquina
```shell
#para instalar rode o comando abaixo
dotnet tool install --global dotnet-ef
```

ao rodar comando abaixo ele irá: 
   - executar a aplicação
   - criar o banco de dados
   - rodar as migrations pelo script init_database.sh

```shell
docker-compose up
```