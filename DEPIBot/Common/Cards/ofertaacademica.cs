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
    public class ofertaacademica
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        private static Activity CreateCarousel()
        {
            var cardmelectro = new HeroCard
            {
                Title = "Maestría en Ciencias en Ingeniería Electrónica",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var cardsist = new HeroCard
            {
                Title = "Maestría en Sistemas Computacionales con Orientación Profesional",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var cardelec = new HeroCard
            {
                Title = "Maestría en Ciencias en Ingeniería Eléctrica",

                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var carddocelec = new HeroCard
            {
                Title = "Doctorado en Ciencias en Ingeniería Eléctrica",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var ofa = new List<Attachment>()
            {
                cardmelectro.ToAttachment(),
                cardsist.ToAttachment(),
                cardelec.ToAttachment(),
                carddocelec.ToAttachment()
            };

            var reply = MessageFactory.Attachment(ofa);
                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}