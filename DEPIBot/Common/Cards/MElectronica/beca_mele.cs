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
    public class beca_mele
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "• PNPC de CONACyT." + "\r\n" +
                "• Programa educativo Roberto Rocca." + "\r\n" +
                "• Secretaría de Relaciones Exteriores(SRE),para estudiantes extranjeros." + "\r\n" +
                "El reconocimiento del programa en los organismos mencionados,permite otorgar becas" +
                " a los estudiantes nacionales o extranjeros hasta por dos años para realizar sus estudios de maestría",
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
