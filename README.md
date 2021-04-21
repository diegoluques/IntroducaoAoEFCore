<h1 align="center" >
  Introdução ao Entity Framework Core
</h1>

<p align="center">
  <a href='#core'>EFCore </a>|
  <a href='#functionalities'>Funcionalidades </a>|
  <a href='#tecnologies'>Tecnologias </a>|
  <a href='#layout'>Layout </a>|
  <a href="#como">Como usar </a>|
  <a href="#uteis">Úteis </a>
</p>

## <p id='core'>💻 EFCore </p>
Curso - Introdução ao Entity Framework Core - Disponibilizado por (https://desenvolvedor.io).

## <p id='functionalities'> ⚙ Funcionalidades </p>
1. 

## <p id='tecnologies'>💻 Tecnologias </p>
Este projeto foi desenvolvido com as seguintes tecnologias:

-  [.NET](https://docs.microsoft.com/pt-br/dotnet/api/?view=net-5.0)
-  [.NET Core 3.1](https://docs.microsoft.com/pt-br/dotnet/api/?view=netcore-3.1)
-  [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## <p id='layout'>🎨 Layout ? </p>


## <p id='como'>💻 Como usar </p>
Para clonar e executar este aplicativo, na linha de comando:

```bash
# Clone este repositório
$ git clone https://github.com/diegoluques/IntroducaoAoEFCore.git

# Vá para o repositório
$ cd IntroducaoAoEFCore

# Executa o comando
$ dotnet run

```

## <p id='uteis'>💻 Úteis </p>
Comandos utilizados durante o curso.

```bash
# 1 - Criar a solução do projeto
$ dotnet new sln -n IntroducaoAoEFCore

# 2 - Criar um projeto do tipo console
$ dotnet new console -n CursoEFCore -f netcoreapp3.1

# 3 - Adicionar o projeto na solução
$ dotnet sln IntroducaoAoEFCore.sln add .\CursoEFCore\CursoEFCore.csproj

# 4 - Adicionar o pacote SqlServer
$ dotnet add .\CursoEFCore\CursoEFCore.csproj package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.5

# 5 - Adicionar o pacote dotnet-ef
$ dotnet tool install --global dotnet-ef --version 3.1.5

# 6 - Adicionar o pacote EF Core Design
$ dotnet add .\CursoEFCore\CursoEFCore.csproj package Microsoft.EntityFrameworkCore.Design --version 3.1.5

# 7 - Adicionar o pacote EF Core Tools
$ dotnet add .\CursoEFCore\CursoEFCore.csproj package Microsoft.EntityFrameworkCore.Tools --version 3.1.5

# 8 - Criar primeira migração
$ dotnet ef migrations add PrimeiraMegracao

# 9 - Criar script para execução no BD primeira migração
$ dotnet ef migrations script -p .\CursoEFCore\CursoEFCore.csproj -o .\CursoEFCore\PrimeiraMigracao.sql

# 10 - Executar script para aplicar a criação/atualizar o banco de dados
$ dotnet ef database update -p .\CursoEFCore\CursoEFCore.csproj -v

# 11 - Gerando Scripts SQL Idempotentes
$ dotnet ef migrations script -p .\CursoEFCore\CursoEFCore.csproj -o .\CursoEFCore\Idempotente.sql --idempotent

# 12 - Rollback de migrações
# - Adicionar uma alteração ao banco de dados.
$ dotnet ef migrations add AdicionarEmail -p .\CursoEFCore\CursoEFCore.csproj
# - Aplicar a primeira alteração no banco de dados, removendo o campo adicionado anteriormente
$ dotnet ef database update PrimeiraMigracao -p .\CursoEFCore\CursoEFCore.csproj -v
# -Excluir o arquivo de migração email. O comando abaixo remove o último arquivo de migração criado
$ dotnet ef migrations remove -p .\CursoEFCore\CursoEFCore.csproj

```