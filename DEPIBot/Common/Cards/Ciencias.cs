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
    public class Ciencias
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Title = "Maestrías en ciencias",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {

                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Eléctrica", value: "https://pgiie.com.mx/plan-de-estudios.html#"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Ingeniería en Electrónica", value: "http://sagitario.itmorelia.edu.mx/pelectron/"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Metalugia", value: "https://sites.google.com/view/posgradometalurgiaitmorelia/inicio")
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
