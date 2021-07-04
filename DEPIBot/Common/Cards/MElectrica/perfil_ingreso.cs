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
    public class perfil_ingreso
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "El perfil del aspirante a la Maestría en Eléctrica:",
                Text = " 1.- La maestría está dirigida a estudiantes egresados de las licenciaturas en:" + "\r\n" +
                $"Ingeniería Eléctrica, Ingeniería Electrónica, Ingeniería Electromecánica o rama afín." + "\r\n" +
                $"2.- Promedio mínimo de 80 o equivalente" + "\r\n"+
                $"3.- Titulados o próximos a titularse" + "\r\n"+
                $"4.- Conocimiento del idioma inglés" + "\r\n"+
                $"5.- Interés en formarse como recursos humanos altamente especializados en los tópicos de frontera de la ingeniería eléctrica, en el marco de las tendencias mundiales en el sector energético y de la reforma energética y la reestructuración del sector eléctrico a nivel nacional." + "\r\n" +
                $"6.- Tener un alto sentido de compromiso y responsabilidad, para dedicarse de tiempo completo a las actividades académicas, de investigación y de desarrollo tecnológico afines a las líneas de investigación del programa de graduados. " + "\r\n" +
                $"Conocimientos requeridos: " + "\r\n" +
                $"1.- Álgebra lineal." + "\r\n" +
                $"2.- Teoría de circuitos." + "\r\n" +
                $"3.- Programación y métodos numéricos." + "\r\n" +
                $"4.- Fundamentos de investigación." + "\r\n" +
                $"NOTA:" + "\r\n" +
                $"*En caso de ser egresado de otras licenciaturas, el Consejo de Posgrado tomará la decisión sobre la posible aceptación del aspirante." + "\r\n" ,
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
