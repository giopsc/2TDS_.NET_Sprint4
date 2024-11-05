
```markdown
# Doracorde API

## Integrantes do Grupo
- **Ana Carolina Tavares** - RM552283
- **Giovanni Paschoalatto** - RM98837
- **Sofia Sprocatti** - RM99208
- **Vinicius Minei** - RM98486
- **Gabriel Lopes Pereira** - RM98023

## Descri��o do Projeto

A **Doracorde API** � uma solu��o desenvolvida para a plataforma "Doracorde: Educa��o Musical Online", que oferece uma abordagem acess�vel e personalizada para o aprendizado musical, especialmente focada em pessoas com defici�ncia visual. Esta API foi constru�da utilizando **ASP.NET Core Web API** e integra funcionalidades para gerenciar cursos e alunos de forma eficiente.

## Arquitetura

Optamos por uma arquitetura **monol�tica** para a API. Essa escolha foi feita considerando a simplicidade e os requisitos do projeto, onde todas as funcionalidades da aplica��o est�o centralizadas em uma �nica aplica��o. Uma arquitetura monol�tica � mais f�cil de gerenciar para um projeto dessa escala e permite maior rapidez no desenvolvimento e manuten��o, sem a necessidade de lidar com a complexidade de microsservi�os.

### Justificativa

A arquitetura monol�tica � ideal para aplica��es de m�dio porte, onde a sobrecarga de gerenciamento e manuten��o de microsservi�os n�o se justifica. Al�m disso, para o prop�sito acad�mico, esta abordagem simplifica a implementa��o e evita os desafios de comunica��o e deploy distribu�do que acompanham a arquitetura de microservices.

## Design Patterns Utilizados

- **Singleton**: O padr�o Singleton foi implementado para o gerenciamento de configura��es, garantindo que apenas uma inst�ncia da classe de configura��o seja criada durante a execu��o da aplica��o.
- **Repository Pattern**: Foi utilizado para abstrair o acesso ao banco de dados, promovendo um design mais modular e permitindo que o c�digo de persist�ncia fique separado da l�gica de neg�cio.
  
## Tecnologias Utilizadas

- **ASP.NET Core Web API** - Framework principal para a cria��o da API.
- **Oracle** - Banco de dados relacional utilizado para persist�ncia de dados.
- **Swagger/OpenAPI** - Para documenta��o autom�tica dos endpoints da API.
- **MongoDB** - Integra��o com um banco de dados NoSQL para opera��es de CRUD.

## Endpoints CRUD

A API oferece endpoints CRUD para gerenciar **Cursos**, incluindo opera��es como:
- `GET /api/curso` - Retorna todos os cursos.
- `GET /api/curso/{id}` - Retorna um curso espec�fico por ID.
- `POST /api/curso` - Cria um novo curso.
- `PUT /api/curso/{id}` - Atualiza um curso existente.
- `DELETE /api/curso/{id}` - Exclui um curso por ID.

## Como Executar a API

### Pr�-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) vers�o 5.0 ou superior.
- [Oracle Database](https://www.oracle.com/database/) configurado e rodando.
- MongoDB configurado, se for utilizar o banco NoSQL para testes.

### Passos para rodar a aplica��o

1. **Clone o reposit�rio:**
   ```bash
   git clone https://github.com/seu-usuario/doracorde-api.git
   cd doracorde-api
   ```

2. **Configure a string de conex�o no arquivo `appsettings.json`:**
   Substitua as informa��es de conex�o com o banco de dados Oracle e MongoDB no arquivo `appsettings.json`.

3. **Restaure as depend�ncias do projeto:**
   ```bash
   dotnet restore
   ```

4. **Compile o projeto:**
   ```bash
   dotnet build
   ```

5. **Execute a aplica��o:**
   ```bash
   dotnet run
   ```

6. **Acesse a documenta��o Swagger:**
   - Ap�s iniciar a API, abra o navegador e acesse: `http://localhost:5000/swagger` para visualizar e testar os endpoints dispon�veis.

### Rodar Testes

O projeto inclui um conjunto de testes de unidade que podem ser executados com o comando:

```bash
dotnet test
```
