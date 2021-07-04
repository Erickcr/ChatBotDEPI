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

namespace DEPIBot.Common.Cards
{
    public static class intentrME
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create() , canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Text = "1.- Debes pertenecer a alguna de las siguientes carreras:" + "\n\n" +
                $" Ingeniería Electrónica," + "\n\n" +
                $" Ingeniería Electríca," + "\n\n" +
                $" Ingeniería en Sistemas Computacionales," + "\n\n" +
                $" o área afín." + "\r\n" +
                $"2.- Un promedio mínimo de 80/100." + "\r\n" +
                $"3.- Aprobar un examen de conocimientos básicos de ingeniería o aprobar el curso propedéutico." + "\r\n" +
                $"4.- Obtener 450 puntos en el examen de inglés TOEFL/ITP." + "\r\n" +
                $"5.- Aprobar la entrevista personal con un comité de Admisión." + "\r\n" +
                $"6.- Entregar dos cartas de recomendación académica, dirigidas al jefe de la DEPI y asignadas por especialistas en el área." + "\r\n" +
                $"7.- Realizar el pago correspondiente." + "\n" ,
        };


        var ofa = new List<Attachment>()
        {
            card1.ToAttachment()
        };

        var reply = MessageFactory.Attachment(ofa);
        reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
        return reply as Activity;
        }
        
    }//
}//
