# Plusoft - BackEnd

Esta é uma implementação do BackEnd responsável por gerenciar as regras de negócio
e rotas de API necessárias para a interação com o banco de dados em questão SQLite.

# Framework

Segundo especificação técnica a linguagem de programação escolhida foi o C#, sendo
assim o projeto foi configurado em um ambiente Linux com a instalação do respectivo
pacote .NET SDK framework. Leia mais em: (https://learn.microsoft.com/pt-br/dotnet/core/install/linux-ubuntu-install?tabs=dotnet9&pivots=os-linux-ubuntu-2404)

# Banco de dados

Para o armazenamento dos dados foi escolhido o SQLite como banco de dados local, facilitando assim
o processo de implantação do sistema em qualquer ambiente ou sistema operacional.
Para implantar o banco de dados:

```sh
dotnet tool install --global dotnet-ef       # Instalar a ferramenta CLI
dotnet ef migrations add <name-of-migration> # Para adicionar um contexto de migration
dotnet ef database update                    # Para realizar o commit de operação na base
```

# Inicialização do Projeto

Para inicializar o projeto é necessário a instalação de alguns pacotes adicionais para
gestão de entidades de bancos de dados e ferramentas necessárias para a execução do
conjunto de API's.

```sh
dotnet add package Microsoft.EntityFrameworkCore.Sqlite # Adicionar suporte ao SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design # Adicionar suporte ao Desing de Entities
```

Para execução em Localhost é necessário adicionar a confiabilidade em certificados https
para conexões seguras: 

```sh
dotnet dev-certs https --trust
```

Para executar o projeto execute o comando:

```sh
dotnet run # No Ubuntu/Linux com SDK .NET
```

Ou apenas dê play se estiver em uma IDE de programação com o Visual Studio ou Code...