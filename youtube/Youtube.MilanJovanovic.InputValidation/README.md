# Validação de dados de entrada API's

> Já se cansou de escrever código de validação bagunçado espalhado por toda a sua base de código? 

Neste [vídeo](https://www.youtube.com/watch?v=vaDDB7BpEgQ) é mostrado como usar o *FluentValidation* no .NET para escrever uma lógica de validação limpa, de fácil manutenção e que realmente faz sentido. Vamos começar instalando o pacote e configurando validadores básicos, depois mergulharemos em exemplos práticos, incluindo o uso do método `RuleFor()` e o útil `InlineValidator` para necessidades de validação rápidas. Você aprenderá tudo o que precisa para começar a usar o *FluentValidation* em seus próprios projetos, com exemplos do mundo real que você realmente poderá aplicar.

## Como executar?

Principal forma utilizada para executar a aplicação foi utilizando a [Visual Code](https://code.visualstudio.com/download), porém pode ser utilizadas outras ferramentas também.

Também é necessário ter instalado a versão da plataforma de desenvolvimento [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0).

### Execução pelo Visual Code

Basta abrir o terminal de sua preferência na raíz do projeto e rodar o seguinte comando:

```
dotnet watch run --urls "https://localhost:7020"
```

OBS.: com o comando acima com watch mode já irá fazer o launch da url da API Open API Docs, que no caso deste projeto é o Swagger.
Caso deseje rodar sem watch mode basta executar o seguinte comando:

```
dotnet run --urls "https://localhost:7020"
```

Aproveite e use os arquivos [`.http`](https://stackoverflow.com/questions/78119582/what-is-api-http-file-in-net-8) para testar os endpoints desenvolvidos neste POC/playground. Com eles tu conseguirá realizar as solicitações HTTP com facilidade através do Visual Code (ou qualquer outro editor de texto ou IDE de preferência) com maior facilidade e também enxergar as respostas.

## Referências

Principais referências logo abaixo:

- [Vídeo base](https://www.youtube.com/watch?v=vaDDB7BpEgQ)
- [Automatically Register Minimal Apis](https://www.milanjovanovic.tech/blog/automatically-register-minimal-apis-in-aspnetcore)
- [How to structure minimal apis](https://www.milanjovanovic.tech/blog/how-to-structure-minimal-apis)
- [HTTP Problem Details RFC](https://datatracker.ietf.org/doc/html/rfc7231)
- [Always Valid Domain Model](https://enterprisecraftsmanship.com/posts/always-valid-domain-model/)
- [Use .http files in Visual Studio](https://learn.microsoft.com/en-us/aspnet/core/test/http-files?view=aspnetcore-8.0)