using System;
using System.Collections.Generic;
using Microsoft.Bot.Schema;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;

namespace DEPIBot.Common.Cards.DElectrica
{
    public class planestudio_DE
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "Plan de Estudios del Doctorado en Ciencias en Ingeniería Eléctrica, consta de 164 créditos académicos a cubrir:",
                Text = " 1.- Para acreditar la materia de Seminario de Investigación el alumno realizará una revisión bibliográfica exhaustiva de su tópico de investigación y presentará un informe oral y por escrito sobre el estado del arte en el mismo, el cual será evaluado por el Comité Tutorial correspondiente." + "\r\n" +
                $"2.- En el Seminario Predoctoral el estudiante formulará el protocolo de investigación y se acreditará mediante la defensa de la Propuesta Doctoral ante el Comité Tutorial, el cual podrá solicitar resultados preliminares." + "\r\n" +
                $"3.- En el Examen Predoctoral el estudiante demostrará, ante el Comité Tutorial, la originalidad de su proyecto de investigación, cuyo resultado podrá ser el siguiente:." + "\r\n" +
                $" -Aprobado. El estudiante podrá continuar como alumno del programa." + "\r\n" +
                $"-Suspendido. En este caso el comité tutorial emitirá uno de los siguientes fallos:" + "\r\n" +
                $"a) Repetir la defensa de la propuesta doctoral, por única vez en un periodo no mayor a seis meses." + "\r\n" +
                $"b) Dar de baja al estudiante del doctorado." + "\r\n" +
                $"4.- En las materias de Proyecto de Investigación I, II, III, IV, y V el alumno presentará de forma escrita y oral los avances de su investigación, el cuál será evaluado por el comité, en base a la calidad y avancé de los resultados presentados y se le asignará una calificacion." + "\r\n"+
                $"5.- Durante su estancia en el Programa Doctoral, el alumno podrá cursar aquellas asignaturas adicionales que considere son necesarias para el desarrollo de su investigación, en común acuerdo con su director de tesis." + "\r\n" +
                $"6.- Una vez acreditados todos los créditos y elaborado su tesis doctoral, el alumno presentará su examen de grado." + "\r\n" ,
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"C:\Users\Lupita Carranza Diaz\source\repos\ChatBotDEPI\DEPIBot\Common\Images\doctorado_electrica.jpeg" } },

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
