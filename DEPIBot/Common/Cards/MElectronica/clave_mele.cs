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
    public class clave_mele
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Nombre: Maestría en Ciencias en Ingeniería Electrónica" + "\r\n" +
                "Clave: MCIE0 - 2011 - 02",


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
