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
    public class campoaccion_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "El campo de acción de la Maestría en Sistemas Computacionales es:",
                Text = " 1.- El egresado podrá desarrollarse en cualquier sector que maneje proyectos que involucren las Tecnologías de Información y Comunicaciones particularmente en las áreas de Seguridad Informática e Ing.de Software y Sistemas Distribuidos." + "\r\n" +
                $"2.- Promover el desarrollo tecnológico como patentes, artículos científicos, participación en congresos y desarrollo de software." + "\r\n" +
                $"3.- Vincular a la industria con los estudiantes a través de una estancia en alguno de los sectores público, privado, social u otros." + "\r\n" +
                $"4.- Desarrollo de investigación aplicada para cubrir necesidades de la industria." + "\r\n" ,

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
