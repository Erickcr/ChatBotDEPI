using System;
using System.Collections.Generic;
using Microsoft.Bot.Schema;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace DEPIBot.Common.Cards
{
    public class grado
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Obtención de Grado:",
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"https://depiitm.000webhostapp.com/images/grado_1.jpeg" } },

            };
            var card2 = new HeroCard
            {
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"https://depiitm.000webhostapp.com/images/grado_2.jpeg" } },

            };
            var card3 = new HeroCard
            {
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"https://depiitm.000webhostapp.com/images/grado_3.jpeg" } },

            };

            var ofa = new List<Attachment>()
            {

                card1.ToAttachment(),
                card2.ToAttachment(),
                card3.ToAttachment()

            };

            var reply = MessageFactory.Attachment(ofa);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
