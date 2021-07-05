using AdaptiveCards;
using System;
using System.Collections.Generic;
using Microsoft.Bot.Schema;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
namespace DEPIBot.Common.Cards.MSistemas
{
    public class perfil_ingreso_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Debes ser un ingeniero o licenciado del campo de sistemas computacionales," +
                " informática, tecnologías de la información y comunicaciones así como otras carreras afines," +
                " preferentemente con experiencia profesional y conocimiento del idioma inglés técnico." + "\r\n" +
                "Mostrar habilidades para leer y comprender escritos técnico - científicos en el idioma inglés.Capacidad de elaborar documentos técnicos," +
                "de desarrollar software y de trabajar en equipo.",
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
