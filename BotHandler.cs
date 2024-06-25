using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

public class BotHandler
{
    public string botToken { get; set; }
    public BotHandler(string token)
    {
        botToken = token;
    }

    public async Task BotHandle()
    {
        var botClient = new TelegramBotClient(botToken);

        using CancellationTokenSource cts = new();

        ReceiverOptions receiverOptions = new()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        botClient.StartReceiving(
            updateHandler: HandleUpdateAsync,
            pollingErrorHandler: HandlePollingErrorAsync,
            receiverOptions: receiverOptions,
            cancellationToken: cts.Token
        );

        var me = await botClient.GetMeAsync();

        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();

        cts.Cancel();
    }
    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message)
            return;

        var getchatmember = await botClient.GetChatMemberAsync("@billioneroo", update.Message.From.Id);
        var getchatmember1 = await botClient.GetChatMemberAsync("@uzkinoland", update.Message.From.Id);
        var getchatmember2 = await botClient.GetChatMemberAsync("@cinemania_uz", update.Message.From.Id);
        if ((getchatmember.Status.ToString() == "Left" || getchatmember.Status.ToString() == null || getchatmember.Status.ToString() == "null" || getchatmember.Status.ToString() == "")
         || (getchatmember1.Status.ToString() == "Left" || getchatmember1.Status.ToString() == null || getchatmember1.Status.ToString() == "null" || getchatmember1.Status.ToString() == "")
         || (getchatmember2.Status.ToString() == "Left" || getchatmember2.Status.ToString() == null || getchatmember2.Status.ToString() == "null" || getchatmember2.Status.ToString() == ""))
        {
            InlineKeyboardMarkup inlineKeyboard = new(new[]
                    {
                    new []
                    {
                        InlineKeyboardButton.WithUrl(text: "Canale 1", url: "https://t.me/billioneroo"),
                        InlineKeyboardButton.WithUrl(text: "Canale 2", url: "https://t.me/uzkinoland"),
                        InlineKeyboardButton.WithUrl(text: "Canale 3", url: "https://t.me/cinemania_uz"),
                    },
                });
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Kanallargaga qo'shiling\nAgar yana qayta chiqsa siz hamma kanalga a'zo bo'lmagansiz\nQo'shilib bo'lishingiz bilan kino kodni yuboring",
                replyMarkup: inlineKeyboard,
                cancellationToken: cancellationToken);
            return;

        }
        else if (message.Text == "1")
        {
            await botClient.CopyMessageAsync(
                chatId: message.Chat.Id,
                fromChatId: -1002148689316,
                messageId: 2,
                cancellationToken: cancellationToken);
            return;
        }
        else
        {
            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Kino kodini to'g'ri kiriting",
                cancellationToken: cancellationToken);
            return;
        }

    }
        public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
        }

 }