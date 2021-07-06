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
    public class proceso_insc
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Necesitas la siguiente documentación:",
                Text = " 1.- Copia del certificado de estudio con promedio mínimo de ochenta(80)." + "\r\n" +
                $"2.- Copia del acta de nacimiento." + "\r\n" +
                $"3.- Dos copias de la CURP (actualizada)." + "\r\n" +
                $"4,- Curriculum Vitae con soporte documental en copia." + "\r\n",
                

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
