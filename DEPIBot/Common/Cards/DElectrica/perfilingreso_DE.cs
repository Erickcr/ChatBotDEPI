using System;
using System.Collections.Generic;
using Microsoft.Bot.Schema;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
namespace DEPIBot.Common.Cards.DElectrica
{
    public class perfilingreso_DE
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Los aspirantes a cursar el Doctorado en Ciencias en Ingeniería Eléctrica deberán:",
                Text = " 1.-  Poseer el grado de maestro en ciencias en un área afín al programa." + "\r\n" +
                $"2.-  Demostrar dominio de los conocimientos considerados como fundamentales para garantizar una conclusión exitosa de sus estudios." + "\r\n" +
                $"NOTAS:" + "\r\n" +
                $"*En caso de ser egresado de otra maestría, el Claustro Doctoral tomará la decisión correspondiente sobre la posible aceptación del aspirante." + "\r\n" +
                $"*En todo caso, el aspirante deberá presentar un examen de admisión cuya forma y contenido será determinado por el Claustro Doctoral." + "\r\n",

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
