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
    public class perfil_egreso_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "Formar maestros en sistemas computacionales con orientación profesional," +
                " con actitud crítica, especialistas en la resolución de problemas prácticos que involucran el uso eficiente" +
                " y eficaz del área de soluciones computacionales dentro de los campos de la seguridad informática," +
                " ingeniería de software y sistemas distribuidos, así como otras áreas afines." + "\r\n" +
                "Los maestros egresados del posgrado," +
                "se integrarán a las empresas y organizaciones de la región," +
                "para resolver problemas particulares y cubrir necesidades del sector empresarial en el área de Seguridad informática e Ingeniería de software y Sistemas Distribuidos.",
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
