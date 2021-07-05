
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
    public static class inntentpeME
    {
       
            public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
            {
                await stepContext.Context.SendActivityAsync(activity: Create(), canelationToken);
            }

            private static Activity Create()
            {

                var card1 = new HeroCard
                {
                    Subtitle = "El Plan de Estudios de la Maestría en Ciencias en Ingeniería Electrónica se desarrolla en 4 semestres y se conforma de la siguiente manera:",
                    Text = " 1.- Cuatro asignaturas Básicas." + "\r\n" +
                    $"2.- Cuatro asignaturas Optativas." + "\r\n" +
                    $"3.- Tres seminarios de Investigación." + "\r\n" +
                    $"4.- Tesis de grado, que se fundamenta en el desarrollo de un trabajo de investigación." + "\r\n" +
                    $"NOTA:" + "\r\n" +
                    $" *Las asignaturas básicas serán asignadas de acuerdo al perfil de ingreso del estudiante." + "\r\n" +
                    $" *Las asignaturas optativas serán determinadas de acuerdo al proyecto de investigación y la LGAC elegida." + "\r\n",
                    Images = new List<CardImage> { new CardImage {Alt = "SpeechPic", Url = @"https://proyectodepi-6d38b.web.app/images/maestria_electronica.jpeg" } }
                    
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

