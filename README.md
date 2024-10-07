# Sistema de Empréstimo de Livros
### Curso: Do Zero à Maestria: Dominando .NET 6 MVC de Ponta a Ponta (Cris Tech)
Este projeto é um sistema web desenvolvido em .NET 6 MVC para gerenciar o empréstimo de livros em uma biblioteca. O sistema permite o cadastro de livros, gerenciamento de usuários e controle de empréstimos e devoluções.

### Funcionalidades
Cadastro de livros: Adicionar, editar e remover livros no sistema.
Gerenciamento de usuários: Registro de novos usuários e administração de perfis.
Controle de empréstimos: Empréstimos e devoluções de livros com controle de datas.
Notificações: Alertas para livros próximos da data de devolução.

### Tecnologias Utilizadas
.NET 6 MVC: Framework para construção da aplicação web.
Entity Framework Core: ORM utilizado para gerenciamento de banco de dados.
SQL Server: Banco de dados utilizado para armazenar informações.
Bootstrap: Framework CSS para estilização do frontend.

### Requisitos
.NET 6 SDK
SQL Server
Visual Studio 2022 ou superior

### Instalação
### Clone o repositório:

git clone https://github.com/seu-usuario/sistema-emprestimo-livros.git

### Navegue até a pasta do projeto:

cd sistema-emprestimo-livros

### Restaure as dependências do projeto:

dotnet restore

### Configure a string de conexão no arquivo appsettings.json com as credenciais do seu banco de dados SQL Server:

"ConnectionStrings": {
  "DefaultConnection": "Server=seu-servidor;Database=seu-banco;User Id=seu-usuario;Password=sua-senha;"
}


### Execute as migrações para criar o banco de dados:

dotnet ef database update

### Execute o projeto:

dotnet run
