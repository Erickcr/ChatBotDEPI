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
    public class Profesionalizantes
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {
            var card1 = new HeroCard
            {
                Title = "Maestrías Profesionalizantes",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {

                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Administración", value: "https://morelia.tecnm.mx/mia/"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Sistemas Computacionales", value: "http://dsc.itmorelia.edu.mx/msc/")
                }
            };


            var ofa = new List<Attachment>()
            {
                card1.ToAttachment()
            };

            var reply = MessageFactory.Attachment(ofa);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
