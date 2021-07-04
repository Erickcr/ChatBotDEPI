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
    public class doc_admin_me
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Documentación requerida para solicitud de admisión Maestría Electrónica:",
                Text = " 1.- Solicitud de admisión (Formato oficial)." + "\r\n" +
                $"2.- Copia de Título de Licenciatura o acta de examen de titulación." + "\r\n" +
                $"3.- Copia del certificado de licenciatura." + "\r\n" +
                $"4.- Currículum vitae." + "\r\n" +
                $"5.- Copia de identificación (IFE o INE)." + "\r\n" +
                $"6.- Carta de exposición de motivos de ingreso (Formato libre)." + "\r\n" +
                $"7.- 2 cartas de recomendación." + "\r\n" +
                $"8.- Constancia de acreditación de TOEFL" + "\r\n" +
                $"9.- Comprobante de pago correspondiente al proceso de admisión." + "\r\n",
               

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
