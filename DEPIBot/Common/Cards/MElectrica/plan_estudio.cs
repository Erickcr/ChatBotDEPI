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

namespace DEPIBot.Common.Cards.MElectrica
{
    public class plan_estudio
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "El Plan de Estudios de la Maestría en Ciencias en Ingeniería Eléctrica, consta de 4 semestres:",
                Text = " 1.- Cuatro asignaturas Básicas (24 créditos)." + "\r\n" +
                $"2.- Cuatro asignaturas Optativas (24 créditos)." + "\r\n" +
                $"3.- Tres seminarios de Investigación (12 créditos)." + "\r\n" +
                $"4.- Tesis (40 créditos)." + "\r\n" +
                $"NOTAS:" + "\r\n"+
                $"*La selección de las asignaturas básicas y optativas se realiza en función del tema de tesis." + "\r\n" +
                $"*En la asignación de seminario se hace una revisión intermedia y semestral de los avances del proyecto de tesis" + "\r\n" +
                $"*La calificación de estas asignaturas es asignada por un comité tutorial" + "\r\n",
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"C:\Users\Lupita Carranza Diaz\source\repos\ChatBotDEPI\DEPIBot\Common\Images\maestria_electrica.jpeg" } },
                
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
