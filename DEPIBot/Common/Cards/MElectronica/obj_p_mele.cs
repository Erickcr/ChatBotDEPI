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
    public class obj_p_mele
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Vincular la investigación con las actividades de los sectores productivo, social, educativo, de investigación y de servicios." + "\r\n" +
                "Formar personal capacitado en la evaluación,diseño,uso y mantenimiento de sistemas relacionados con" +
                " Procesamiento de Señales y Electrónica de Potencia." + "\r\n" +
                "Realizar,analizar y evaluar estudios de impacto tecnológico,social y ambiental" +
                " en sus diferentes modalidades y relacionados con Procesamiento de Señales y Electrónica de Potencia.",


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
