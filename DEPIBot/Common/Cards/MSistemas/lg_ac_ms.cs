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
    public class lg_ac_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Seguridad Informática:"+ "\r\n"+
                "Se promueve un uso efectivo,seguro y confiable de las TI. " +
                "Acorde con las necesidades y exigencias de los diversos sectores empresariales,nacionales e internacionales apegados a estándares." + "\r\n" +
                "Ingeniería de Software y Sistemas Distribuidos:" + "\r\n" +
                "Se desarrollan e implementan métodos, herramientas y técnicas cuya finalidad es producir software de calidad" +
                " en un ambiente cliente servidor y sistemas distribuidos, usando TI de vanguardia." + "\r\n" +
                "En ambas áreas del conocimiento se fomenta la formación de líderes nacionales y pioneros mundiales en la investigación aplicada" +
                ", innovación y desarrollo tecnológico, utilizando métodos, procesos, técnicas y herramientas de alta Ingeniería y uso aplicado" +
                " de la ciencia." ,


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
