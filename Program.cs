using Telegram.Bot;
using Telegram.Bot.Types;

if (args.Length != 1)
{
    System.Console.WriteLine("Укажите токен");
    return;
}
string token = args[0];

var client = new TelegramBotClient(token);

client.StartReceiving(
    (c, arg, _) =>
    {
        return c.SendMessage(
            chatId: arg.Message.Chat.Id,
            text: $"{arg.Message.Text} получено!",
            replyParameters: new ReplyParameters
            {
                MessageId = arg.Message.Id
            }
        );
    }, (_, _, _) => Task.CompletedTask
);

System.Console.WriteLine("Бот запущен");
await Task.Delay(-1);