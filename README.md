É imprescindível a criação de um banco de dados MYSQL ou MariaDB com os dados que serão inclusos na string de conexão. Para isso execute o arquivo
"BKP Catalogo Test.sql" em um client mysql de seu servido, este é um dump do banco de desenvolvimento, o mesmo contém a criação do banco de dados 
caso não exista, além é claro das tabelas.

Para funcionamento da aplicação em primeira instância é necessário publicar o projeto em um servidor IIS, 
este será o responsável por configurar a porta de disponibilidade da aplicação, que posteriormente pode ser alterada no projeto cliente CatalogoWA, sendo que 
este segundo acessará por esta porta configurada no IIS.

Dentre os arquivos gerados para publicação no ISS existe o arquivo appsettings.json onde onde no atributo "DefaultConnection" 
é possível alterar/configurar a string de conexão> Segue conteúdo do arquivo de configuração para melhor visualização:

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=127.0.0.1; port=3306; database=catalogo; user=catalogo; password=catalogo1010; Persist Security Info=False; Connect Timeout=300"
  }
}

