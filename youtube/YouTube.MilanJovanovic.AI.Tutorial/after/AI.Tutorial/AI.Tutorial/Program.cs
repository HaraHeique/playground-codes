using AI.Tutorial;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/*
INSTRUÇÕES DE USO:
Para rodar o LLM local basta executar o arquivo o container do arquivo docker_ollama.txt que está adicionado na solution deste projeto!
Os comandos que devem ser executado no docker baseado neste código fonte são:
    docker run --gpus all -d -v ollama_data:/root/.ollama -p 11434:11434 --name ollama ollama/ollama:latest
    docker exec -it ollama ollama pull llama3
 */
var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "llama3"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

//await DefaultPrompt.Execute(chatClient);
await InteractiveHistoryPrompt.Execute(chatClient);
//await SummarizationPrompt.Execute(chatClient);
//await StronglyTypedSummarizationPrompt.Execute(chatClient);