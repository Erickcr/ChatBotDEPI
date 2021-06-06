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
    public class doctorados
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        private static Activity CreateCarousel()
        {
            
            var cardElectrica = new HeroCard
            {
                Title = "Doctorado en Ciencias en Ingeniería Eléctrica",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var doc = new List<Attachment>()
            {
         
                cardElectrica.ToAttachment()
            };

            var reply = MessageFactory.Attachment(doc);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}

