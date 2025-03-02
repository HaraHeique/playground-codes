using Microsoft.Extensions.AI;

namespace AI.Tutorial;

internal class DefaultPrompt
{
    public static async Task Execute(IChatClient chat)
    {
        var chatCompletion = await chat.CompleteAsync("What is .NET? Reply in 50 words max.");

        Console.WriteLine(chatCompletion.Message.Text);
    }
}

internal class InteractiveHistoryPrompt
{
    public static async Task Execute(IChatClient chat)
    {
        var chatHistory = new List<ChatMessage>();

        while (true)
        {
            // Get user prompt and add to chat history
            Console.WriteLine("Your prompt:");
            var userPrompt = Console.ReadLine();
            chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

            // Stream the AI response and add to chat history
            Console.WriteLine("AI Response:");
            var chatResponse = "";

            await foreach (var item in chat.CompleteStreamingAsync(chatHistory))
            {
                Console.Write(item.Text);
                chatResponse += item.Text;
            }

            chatHistory.Add(new ChatMessage(ChatRole.Assistant, chatResponse));
            
            Console.WriteLine(Environment.NewLine);
        }
    }
}

internal class SummarizationPrompt
{
    public static async Task Execute(IChatClient chat)
    {
        // Let's try summarization
        var posts = Directory.GetFiles("posts").Take(5).ToArray();
        foreach (var post in posts)
        {
            string prompt =
                $$"""
         You will receive an input text and the desired output format.
         You need to analyze the text and produce the desired output format.
         You not allow to change code, text, or other references.

         # Desired response

         Only provide a RFC8259 compliant JSON response following this format without deviation.

         {
            "title": "Title pulled from the front matter section",
            "summary": "Summarize the article in no more than 100 words"
         }

         # Article content:

         {{File.ReadAllText(post)}}
         """;

            var chatCompletion = await chat.CompleteAsync(prompt);

            Console.WriteLine(chatCompletion.Message.Text);
            Console.WriteLine(Environment.NewLine);
        }
    }
}

internal class StronglyTypedSummarizationPrompt
{
    public static async Task Execute(IChatClient chat)
    {
        // Let's try a strongly typed response
        var posts = Directory.GetFiles("posts").Take(5).ToArray();
        
        foreach (var post in posts)
        {
            string prompt =
                $$"""
                  You will receive an input text and the desired output format.
                  You need to analyze the text and produce the desired output format.
                  You not allow to change code, text, or other references.

                  # Desired response

                  Only provide a RFC8259 compliant JSON response following this format without deviation.

                  {
                     "title": "Title pulled from the front matter section",
                     "tags": "Array of tags based on analyzing the article content. Tags should be lowercase."
                  }

                  # Article content:

                  {{File.ReadAllText(post)}}
                """;

            var chatCompletion = await chat.CompleteAsync<PostCategory>(prompt);

            //Console.WriteLine(chatCompletion.Message.Text);
            Console.WriteLine($"{chatCompletion.Result.Title}. Tags => {string.Join(",", chatCompletion.Result.Tags)}");
            Console.WriteLine(Environment.NewLine);
        }
    }

    internal class PostCategory
    {
        public string Title { get; set; } = string.Empty;
        public string[] Tags { get; set; } = [];
    }
}
