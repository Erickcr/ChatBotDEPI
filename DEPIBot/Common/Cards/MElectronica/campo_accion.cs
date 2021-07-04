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

namespace DEPIBot.Common.Cards.MElectronica
{
    public class campo_accion
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Campo de acción en la Maestría en Electrónica",
                Text = " La maestría cuenta con dos Líneas Generadoras del Conocimiento que son Procesamiento de Señales y Electrónica de Potencia." + "\r\n" +
                $" >> Electrónica de Potencia:" + "\r\n" +
                $"Es indispensable en el sector industrial sea éste primario, secundario o terciario, ya que en cualquier proceso industrial se requiere el uso adecuado y eficaz de la energía, y esta área del conocimiento trata de la conversión de la energía, la calidad en la energía y el uso eficiente de los sistemas de potencia." + "\r\n" +
                $" >> Procesamiento de Señales:" + "\r\n" +
                $"se requiere en unidades hospitalarias, empresas tecnológicas, centros de investigación y los diversos organismos que se integran en los sectores industriales, educativos,  de salud y de servicios." + "\r\n" ,

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
