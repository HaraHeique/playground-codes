# Microsoft AI Models

Descubra como construir aplicativos de IA poderosos em .NET usando as ferramentas e frameworks mais recentes. Explore Large Language Models (LLMs) e Ollama - uma ferramenta incrível que permite que você execute modelos de IA localmente em sua máquina.

O Microsoft.Extensions.AI está revolucionando o desenvolvimento de IA em .NET ao fornecer uma maneira simples e unificada de interagir com modelos de linguagem.

OBS.: Todo código fonte presente aqui foi disponibilizado pelo próprio Milan através do seguinte [link](https://www.youtube.com/redirect?event=video_description&redir_token=QUFFLUhqazVoaE9ZUjRxNmJLRk9aLVdYVlhxQ2pfVXo1d3xBQ3Jtc0tsTVNMMW1QUFU3TlJYeHRueWdDNG4td2tNZlE1V2RDMDFuaV9qSHhtTzZYeWwteER5ZVpnaVRvY3gwU1J0SjlwLUdPRTJwUGF6WGZKbWVmOTJoS3ZucVJ4bEtVQy1qYXJYSWVlZlVtMTBmNEh1V3JTUQ&q=https%3A%2F%2Fthe-dotnet-weekly.kit.com%2Fmsft-ai&v=4B3ppx2U8bE).

## Como executar?

Principal forma utilizada para executar a aplicação foi utilizando a IDE [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/), porém pode ser utilizadas outras ferramentas também.

Também é necessário ter instalado a versão da plataforma de desenvolvimento [.NET 9](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0).

### Execução pelo Visual Studio

Basta abrir a .sln o projeto no diretório `/after` e executar o projeto.
Note que o único profile existente é o que roda o docker-compose.

Caso não dê certo então rode respectivamente o container docker da ferramenta `Ollama` localmente, assim como a LLM escolhia, que no nosso caso será a `llama3`:

    docker run --gpus all -d -v ollama_data:/root/.ollama -p 11434:11434 --name ollama ollama/ollama:latest
    docker exec -it ollama ollama pull llama3

OBS. 1: qualquer coisa assista ao vídeo na seção de referências.
OBS. 2: dependendo da sua máquina não consiguirá rodar a LLM na sua máquina. Daí tem que mexer nas configurações ou tentar em outra.

## Referências

Principais referências logo abaixo:

- [Vídeo base](https://www.youtube.com/watch?v=4B3ppx2U8bE)
- [AI For .NET Developers](https://learn.microsoft.com/en-us/dotnet/ai/)
- [Ollama](https://ollama.com/)
- [O que é Ollama](https://www.hostinger.com.br/tutoriais/o-que-e-ollama)