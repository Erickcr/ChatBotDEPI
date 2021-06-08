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
    public class informacion
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {
            var card1 = new HeroCard
            {
                //Title = "Sobre Nosotros",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    //ver los tipos de valores en el url de ..docs.microsoft.com/es-es/azure/bot-service/bot-builder-howto-add-media-attachments?view=azure-bot-service-4.0&tabs=csharp
                    new CardAction(ActionTypes.OpenUrl, title: "1. Sobre Nosotros", value: "https://www.morelia.tecnm.mx/"),
                    new CardAction(ActionTypes.PostBack, title: "2. Oferta Academica", value: "¿cual es la oferta academica?"),
                    new CardAction(ActionTypes.PostBack, title: "3. Convenios", value: "¿Que convenios tienen?"),
                    new CardAction(ActionTypes.PostBack, title: "4. Contacto", value: "información de contacto" )
                }
            };
            //https://www.morelia.tecnm.mx/ Maestría en Ciencias en Ingeniería Electrónica \n\n" +
            //"Maestría en Sistemas Computacionales con Orientación Profesional \n\n " + "Maestría en Ciencias en Ingeniería Eléctrica \n\n" + "Doctorado en Ciencias en Ingeniería Eléctrica" Jefe de la DEPI \n\n" + "Dr Héctor Javier Vergara Hernandéz \n\n" + "Correo de contacto: correo @morelia.tecnm.mx \n\n" + "Númro telefónico de contacto: 7722772277 \n\n"
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