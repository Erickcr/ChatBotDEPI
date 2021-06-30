using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder;

namespace DEPIBot.Common.Cards
{
    public class contacto
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        // WaterfallStepContext stepContext, RecognizerResult luisResult , DialogContext stepContext, CancellationToken canelationToken

        private static Activity CreateCarousel()
        {

            var card1 = new HeroCard
            {

                Title = "Maestrías Profesionalizantes",
                Text = $"Maestría en Administración: {Environment.NewLine}" + "\r\n" + $"☏ 9922113322{Environment.NewLine}" + "\n" +
                       $"Maestría en Sistemas Computacionales: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}"
                //Text = $"El correo de contacto es {Environment.NewLine}" + $"cordinadoor@morelia.tecnm.mx",
                //Text = $"Nos encontramos en {Environment.NewLine}Avenida Tecnologico no. Mrelia Michoacán"

                //await stepContext.Context.SendActivityAsync(phoneDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(emailDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(addressDetail, cancellationToken: cancellationToken);
            };

            var card2 = new HeroCard
            {
                Title = "Maestrías en ciencias",
                Text = $"Maestría en Ciencias en Eléctrica: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}" + "\n" +
                       $"Maestría en Ciencias en Ingeniería en Electrónica: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}" + "\n" +
                       $"Maestría en Ciencias en Metalugia: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}"
                //string emailDetail = $"El correo de contacto es {Environment.NewLine}" + $"cordinadoor@morelia.tecnm.mx",
                //string addressDetail = $"Nos encontramos en {Environment.NewLine}Avenida Tecnologico no. Mrelia Michoacán"

                //await stepContext.Context.SendActivityAsync(phoneDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(emailDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(addressDetail, cancellationToken: cancellationToken);
            };

            var card3 = new HeroCard
            {

                Title = "Doctorados",
                Text = $"Doctorado en Ciencias en Ingeniería: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}" + "\n" +
                       $"Doctorado en Ciencias en Ingeniería Eléctrica: {Environment.NewLine}" + "\n" + $"☏ 9922113322{Environment.NewLine}"
                //Text = $"El correo de contacto es {Environment.NewLine}" + $"cordinadoor@morelia.tecnm.mx",
                //Text = $"Nos encontramos en {Environment.NewLine}Avenida Tecnologico no. Mrelia Michoacán"

                //await stepContext.Context.SendActivityAsync(phoneDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(emailDetail, cancellationToken: cancellationToken);
                //await stepContext.Context.SendActivityAsync(addressDetail, cancellationToken: cancellationToken);
            };
            var doc = new List<Attachment>()
            {
         
                card1.ToAttachment(),
                card2.ToAttachment(),
                card3.ToAttachment()
            };

            var reply = MessageFactory.Attachment(doc);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}

