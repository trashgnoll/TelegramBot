using SkillOverbot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SkillOverbot.Controllers
{
    public class TextMessageController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":

                    // Объект, представляющий кноки
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                        InlineKeyboardButton.WithCallbackData($" Считать символы ", $"len"),
                        InlineKeyboardButton.WithCallbackData($" Считать сумму ", $"sum")
                    });

                    // передаем кнопки вместе с сообщением (параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(
                        message.Chat.Id,
                        $"<b>Этот бот вот что умеет:</b>" +
                        $"{Environment.NewLine}- считает количество символов в тексте" +
                        $"{Environment.NewLine}- и вычисляет сумму чисел",
                        cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;
                default:
                    string messageType = _memoryStorage.GetSession(message.Chat.Id).MessageType;
                    string result = messageType switch
                    {
                        "len" => Parser.LenMode(message.Text),
                        "sum" => Parser.SumMode(message.Text),
                        "" => "Сначала нужно выбрать режим",
                        _ => String.Empty
                    };
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
                    break;
            }
        }
    }
}
