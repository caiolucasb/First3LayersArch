# **API REST - Ilia Test**

## **Tecnologias usadas**
-   [.NET 5](https://docs.microsoft.com/en-us/dotnet/?WT.mc_id=dotnet-35129-website)
-   [Entity Framework](https://docs.microsoft.com/pt-br/ef/)
-   [MsSql](https://docs.microsoft.com/pt-br/sql/?view=sql-server-ver15)
-   [Swagger](https://swagger.io/docs/)
-   [xUnit](https://xunit.net/)

## **Clonar projeto**

Clone o repositório do GitHub

```bash
    # Clone o repositório
    > git clone https://github.com/caiolucasb/IliaSoftwareTest.git

    # Acessar repositorio
    > cd IliaSoftwareTest
```

## **Rodar o Projeto via CLI**

**Para rodar o projeto é necessário ter [.NET](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) instalado na sua máquina**

Após instalar o framework é necessario estar no mesmo diretório da api para rodar o projeto

```bash
    # Ir para o diretório da API
    > cd IST && cd IST.API
```

Agora basta executar o seguinte comando

```bash
    # Rodar o projeto
    > dotnet run
```
Assim que o projeto rodar acesse "https://localhost:5001/swagger"

## **Testes Unitários**

Os Testes foram feitos com [xUnit](https://xunit.net/)

Para rodar os testes da aplicação é necessário fazer os passos acima.

```bash
    # Ir para o diretório dos testes
    > cd IST && cd IST.BLL.TEST
```

Agora basta executar o seguinte comando

```bash
    # Rodar testes
    > dotnet test
```