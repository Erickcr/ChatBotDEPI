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
    public class lg_ac_mele
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Procesamiento de Señales:" + "\r\n"+
                "• Aplicaciones en Telemetría y TICs." + "\r\n" +
                "• Aplicaciones en Instrumentación." + "\r\n" +
                "• Control Sistemas Embebidos Redes Inteligentes." + "\r\n" +
                "Electrónica de Potencia:" + "\r\n" +
                "• Energías Renovables." + "\r\n" +
                "• Sistemas de Iluminación." + "\r\n" +
                "• Calidad de la Energía",


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
