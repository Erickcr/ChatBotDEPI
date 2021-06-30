using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder;

namespace DEPIBot.Common.Cards
{
    public class maestrias
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        private static Activity CreateCarousel()
        {

            var card1 = new HeroCard
            {
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(ActionTypes.PostBack, title: "Maestrías Profesionalizantes", value: "profesionalizantes"),
                    new CardAction(ActionTypes.PostBack, title: "Maestrías en Ciencias", value: "ciencias")
                }
            };

            var mae = new List<Attachment>()
            {
                card1.ToAttachment()
            };

            var reply = MessageFactory.Attachment(mae);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
