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
    public class objetivo_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "• Vincular a los alumnos egresados con las empresas desarrolladoras," +
                " a través de convenios, proyectos en colaboración, estancias profesionales, cursos entre otros." + "\r\n" +
                "• Ser un referente a nivel nacional,mediante estudios de posgrados,la actualización,certificaciones," +
                "estancias en centros de investigación e industria o empresas.Capacitando a la planta de investigadores." + "\r\n" +
                "• Proyectos de investigación aplicados a nivel local,regional,nacional e internacional." + "\r\n" +
                "• Publicar artículos en revistas especializada, además de participar en congresos nacionales e internacionales." + "\r\n" +
                "• A corto plazo solicitar el ingreso al PNPC como posgrado de reciente creación.",
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
