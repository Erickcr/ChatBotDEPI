using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder;

namespace DEPIBot.Common.Cards
{
    public class contacto_tesis
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        private static Activity CreateCarousel()
        {

            var card1 = new HeroCard
            {

                Title = "Para mayor información en el proceso de tu tesis debes contactarte a:",
                Text = $"Correo electrónico: {Environment.NewLine}" + "\r\n" + $"✉ tutulacion@morelia.tecnm.mx{Environment.NewLine}" + "\n" +
                       $"Número telefónico: {Environment.NewLine}" + "\n" + $"☏ (443) 312 1570 ext. 245{Environment.NewLine}",
            };

            var doc = new List<Attachment>()
            {

                card1.ToAttachment(),
            };

            var reply = MessageFactory.Attachment(doc);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}
