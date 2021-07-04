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
    public class perfil_egreso
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "El egresado del programa de la Maestría en Eléctrica:",
                Text = " adquieren una formación científica y tecnológica que les permite tener:" + "\r\n" +
                $"1.- Conocimientos sólidos y de frontera en el área de la ingeniería eléctrica que han cursado." + "\r\n" +
                $"2.- Capacidad para realizar actividades de investigación, desarrollo tecnológico y docencia." + "\r\n" +
                $"3.- Capacidad para identificar, analizar y proponer soluciones a problemas específicos en las áreas de sistemas eléctricos de potencia y distribución en los ámbitos de investigación, desarrollo tecnológico y docencia." + "\r\n" +
                $"4.- Manejo crítico de la información de las fuentes técnico-científicas especializadas." + "\r\n" +
                $"5.- Habilidad de comunicar ideas en la forma de artículos y presentaciones en foros profesionales." + "\r\n"+
                $"6.- Facultad de impartir docencia a nivel licenciatura y posgrado." + "\r\n"+
                $"7.- Habilidad de dar asesorías y consultoría a organismos públicos y privados del sector energético." + "\r\n"+
                $"8.- Alto compromiso con la preservación del medio ambiente, el desarrollo de la ciencia y el beneficio social." + "\r\n"+
                $"9.- La capacidad para realizar estudios de doctorado dentro y fuera del país." + "\r\n",

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
