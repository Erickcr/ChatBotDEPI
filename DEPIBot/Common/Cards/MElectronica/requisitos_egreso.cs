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
    public class requisitos_egreso
    {

        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Los requisitos de egreso para los alumnnos de la Maestría en Electrónica son los siguientes:",
                Text = " Para obtener el grado de Maestro en Ciencias en Ingeniería Electrónica se debe:" + "\r\n" +
                $"1.- Cubrir 100 créditos aprobando todas las asignaturas con un promedio mínimo de 80." + "\r\n" +
                $"2.- Obtener 500 puntos en el examen TOEFL/ITP." + "\r\n" +
                $"3.- Desarrollar un trabajo individual de tesis." + "\r\n" +
                $"4.- Contar con la autorización de su Comité Tutorial para la impresión del documento final." + "\r\n" +
                $"5.- Presentar la defensa de tesis (Examen de grado)." + "\r\n" +
                $"6.- No tener adeudos con la Institución." + "\r\n" +
                $"7.- Realizar la publicación de un artículo científico." + "\r\n" ,

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
