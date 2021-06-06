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

            var cardElectronica = new HeroCard
            {
                Title = "Maestría en Ciencias en Ingeniería Electrónica",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var cardSistemas = new HeroCard
            {
                Title = "Maestría en Sistemas Computacionales con Orientación Profesional",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var cardElectricaM = new HeroCard
            {
                Title = "Maestría en Ciencias en Ingeniería Eléctrica",

                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(){Title = "Ver", Value = "https://www.morelia.tecnm.mx/", Type = ActionTypes.OpenUrl}
                }
            };

            var mae = new List<Attachment>()
            {
                cardElectronica.ToAttachment(),
                cardSistemas.ToAttachment(),
                cardElectricaM.ToAttachment()
            };

            var reply = MessageFactory.Attachment(mae);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
