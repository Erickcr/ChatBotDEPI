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
    public class perfilegreso_DE
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "La formación de los egresados del Doctorado en Ciencias en Ingeniería Eléctrica les permite tener:",
                Text = " 1.- La capacidad de generar conocimientos científicos y/o tecnológicos originales, a través del planteamiento y desarrollo de proyectos de investigación." + "\r\n" +
                $"2.- La habilidad de incorporarse y participar en trabajos de investigación científica y desarrollo tecnológico, aplicando sus conocimientos y metodologías en forma original e innovadora." + "\r\n" +
                $"3.- La capacidad de participar en actividades docentes a nivel de licenciatura y posgrado en instituciones de educación superior y centros especializados." + "\r\n" +
                $"4.- La facultad de detectar y analizar problemas, innovar, mejorar y adaptar nuevas tecnologías en procesos industriales." + "\r\n" +
                $"5.- Manejo crítico de la información de las fuentes técnico-científicas especializadas." + "\r\n" +
                $"6.- Habilidad de comunicar ideas tanto de forma escrita como oral en artículos indexados y presentaciones en foros internacionales." + "\r\n" +
                $"7.- Habilidad de dar asesorías y consultoría a organismos públicos y privados del sector energético." + "\r\n" +
                $"8.- Alto compromiso con la preservación del medio ambiente, el desarrollo de la ciencia y el beneficio social." + "\r\n" +
                $"9.- La capacidad para realizar estudios posdoctorales dentro y fuera del país." + "\r\n",
              

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
