
# Nepen Desafio

Link do desafio : https://gitlab.nepen.org.br/Challenges/desafio-fullstack




## Tecnologias utilizadas

- .Net (C#) - indicado no desafio
- Angular (JavaScript) - indicado no desafio
- PostgreSql (Sql) - indicado no desafio
- O Uso da Api IMDB (Api de Filmes)

## Arquitetura 

- No começo pensei em criar o projeto em Clean Architeture,
  entretanto vi que a api era muito simples e pequena para 
  ser utilizada com uma Arquitetura de projetos "grandes".
- Fiz uma divisão de forma organizada, que não atrapalhou
  no processo de execução.

## Funcionalidades

- Adicionar filmes da Api IMDB para a sua biblioteca com comentários dinâmicos.
- Edição de dados (Possibilidade de modificar nome, descrição e comentários do Filme)
- Login (Token/Autenticação e Autorização)


## Autores

- [@ProHenriqueLima](https://www.github.com/ProHenriqueLima)


## Como executar 

Entre primeiramente em ApiFilmes.Net no arquivo appsettings.Development.json e no appsettings.json e configure o Database. (Lembrando que é necessário criar um banco com o nome que for passado aqui).

```bash
  "PostgreSQL": "User ID=postgres;Password={SuaSenha};Host=localhost;Port={SuaPorta};Database=FilmeNepen;"
```

Após esse passo execute o comando a seguir : 

```bash
  dotnet ef database update
```
E o BackEnd já está pronto para rodar :

```bash
  dotnet run
```

Para configurar o frontend é necessário entrar em AppFilmesAngular/NepenFilmes e executar o comando :

```bash
  npm install || npm i
```

Depois é só utilizar o comando para rodar : 

```bash
  ng serve
```

No console vai estar aparecendo a porta utilizada, para entrar no projeto.
    