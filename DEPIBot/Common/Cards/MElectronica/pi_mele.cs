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
    public class pi_mele
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "• Estarás capacitado para conocer, comprender y analizar problemas relacionados con áreas de Procesamiento de Señales y Electrónica de Potencia." + "\r\n" +
                "• Tendrás los conocimientos para abordar la problemática de impacto tecnológico en el ámbito industrial, social, educativo,de investigación y de servicios." + "\r\n" +
                "• Contarás con las bases teóricas y prácticas que te permitan interrelacionarte con profesionistas de otras" +
                " ramas en la solución sustentable de problemas de impacto tecnológico, " +
                "social y ambiental.",


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
