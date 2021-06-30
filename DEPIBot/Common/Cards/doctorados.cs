﻿using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Builder;

namespace DEPIBot.Common.Cards
{
    public class doctorados
    {
        public static async Task ToShow(DialogContext stepContext, CancellationToken canelationToken)
        {
            await stepContext.Context.SendActivityAsync(activity: CreateCarousel(), canelationToken);
        }

        private static Activity CreateCarousel()
        {

            var card1 = new HeroCard
            {
                Title = "Doctorados",
                //Images =  new List<CardImage> { new CardImage("")}
                Buttons = new List<CardAction>()
                {
                    new CardAction(ActionTypes.OpenUrl, title: "Doctorado en Ciencias en Ingeniería", value: "http://sagitario.itmorelia.edu.mx/dci/"),
                    new CardAction(ActionTypes.OpenUrl, title: "Doctorado en Ciencias en Ingeniería Eléctrica", value: "https://www.pgiie.com.mx/plan-de-estudios_pgiie_doctorado.html")
                }
            };

            var doc = new List<Attachment>()
            {
         
                card1.ToAttachment()
            };

            var reply = MessageFactory.Attachment(doc);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
            return reply as Activity;
        }
    }
}

