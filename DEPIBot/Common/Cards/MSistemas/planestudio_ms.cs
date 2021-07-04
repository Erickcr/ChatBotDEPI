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
    public class planestudio_ms
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
        }

        private static Activity Create()
        {

            var card1 = new HeroCard
            {
                Subtitle = "El Plan de Estudios de la Maestría en Sistemas Computacionales, consta de 4 semestres:",
                Text = " 1.- Cuatro asignaturas Básicas." + "\r\n" +
                $"2.- Cuatro asignaturas Optativas." + "\r\n" +
                $"3.- Tres seminarios de Investigación." + "\r\n" +
                $"4.- Tesis/Estancia." + "\r\n" +
                $"Materias optativas por líneas de generación:" + "\r\n",
                Images = new List<CardImage> { new CardImage { Alt = "SpeechPic", Url = @"C:\Users\Lupita Carranza Diaz\source\repos\ChatBotDEPI\DEPIBot\Common\Images\maestria_sistemas.jpeg" } },
                Buttons = new List<CardAction>()
                {
                     new CardAction(ActionTypes.DownloadFile ,"Seguridad Informática", value:  @"C:\Users\Lupita Carranza Diaz\source\repos\ChatBotDEPI\DEPIBot\Common\Images\ing_soft.jpeg"),
                    new CardAction(ActionTypes.DownloadFile ,"Ing de Software y Sistemas Distribuidos ", value:  @"C:\Users\Lupita Carranza Diaz\source\repos\ChatBotDEPI\DEPIBot\Common\Images\seg_info.jpeg")
                }
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
