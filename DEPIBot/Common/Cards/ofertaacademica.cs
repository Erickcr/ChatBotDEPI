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

                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Administración", value: "https://depiitm.000webhostapp.com/POSGRADOS/ADMINISTRATIVA/mia.php"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Sistemas Computacionales", value: "https://depiitm.000webhostapp.com/POSGRADOS/SISTEMAS/index.php")
                }
            };

            var card2 = new HeroCard
            {
                Title = "Maestrías en ciencias",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {

                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Eléctrica", value: "https://www.pgiie.com.mx"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Ingeniería en Electrónica", value: "https://depiitm.000webhostapp.com/POSGRADOS/ELECTRONICA/index.php"),
                    new CardAction(ActionTypes.OpenUrl, title: "Maestría en Ciencias en Metalugia", value: "https://sites.google.com/view/posgradometalurgiaitmorelia")
                }
            };

            var card3 = new HeroCard
            {
                Title = "Doctorados",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(ActionTypes.OpenUrl, title: "Doctorado en Ciencias en Ingeniería", value: "https://depiitm.000webhostapp.com/POSGRADOS/INGENIERIA/index.php"),
                    new CardAction(ActionTypes.OpenUrl, title: "Doctorado en Ciencias en Ingeniería Eléctrica", value: "https://www.pgiie.com.mx")
                }
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