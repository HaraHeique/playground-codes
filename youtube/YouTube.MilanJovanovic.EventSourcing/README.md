# Validação de dados de entrada API's

Aprenda os fundamentos do Event Sourcing no .NET com este guia para iniciantes. Exploraremos como armazenar o estado do seu aplicativo como uma sequência de eventos em vez de apenas o estado atual. Começando com os conceitos principais, abordaremos a modelagem de eventos, a criação de agregados, a aplicação de eventos, a implementação de lógica de negócios e a construção de projeções para consultas eficientes. Perfeito para desenvolvedores .NET que buscam entender os padrões do Event Sourcing e sua implementação prática. Exemplos de código incluídos.

## O que é Event Sourcing

Event Sourcing é uma padrão de design de arquitetura do qual guardamos as mudanças de estado do nosso domínio através de eventos imutáveis dentro de uma stream append only log. Ou seja, é sobre persistir as mudanças de estado dos seus modelos de domínio numa série sequencial de eventos.

Alguns build blocks do Event Sourcing são:

### Events

Os eventos são fatos imutáveis que ocorreram no nosso domínio e com intenções do domínio. Exemplos de eventos na imagem abaixo:

![events](docs/events.png)

### Streams

Stream de eventos, ou seja, um append only log de eventos para um determinado identificador do conjunto de eventos. Logo é o local onde guardamos os eventos de um determinada AGREGADO. Exemplo de uma Stream de eventos abaixo:

![streams](docs/stream-of-events.png)

### State

Quando usamos event sourcing nós nunca guardamos o estado final (current state) do nosso domínio, e sim um conjunto de fatos que ocorreram (eventos) que representam o estado.
Para reconstruir o estado de um objeto do nosso domínio em um dado período do tempo para peformarmos operações (lógicas de negócio) nós precisamos de obter o stream de eventos e recalcularmos aplicando o replay dos eventos. Abaixo mostra exatamente o que foi falado anteriormente:

![replay-of-events](docs/current-state.png)

Note que foi obtida a stream dos eventos de um determinado objeto do domínio (identificador único) e feito o replay dos eventos dele para obter o estado corrente OU estado até um determinado ponto no tempo. 

## Como executar? (TODO: MUDAR AQUI)

Principal forma utilizada para executar a aplicação foi utilizando a [Visual Code](https://code.visualstudio.com/download), porém pode ser utilizadas outras ferramentas também.

Também é necessário ter instalado a versão da plataforma de desenvolvimento [.NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0).

### Execução pelo Visual Code (TODO: MUDAR AQUI)

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

- [Vídeo base](https://www.youtube.com/watch?v=gvW9uJSFujA)
- [Introduction to Event Sourcing for .NET Developers](https://www.milanjovanovic.tech/blog/introduction-to-event-sourcing-for-net-developers)