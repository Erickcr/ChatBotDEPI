using DEPIBot.Common.Cards;
using EchoBot.Infrastructure;
using EchoBot.Infrastructure.QnAMakerAI;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEPIBot.Dialogs
{
    public class RootDialog: ComponentDialog
    {
        private readonly ILuisService _luisService;
        private readonly IQnAMakerAIService _qnaMakerAIService;

        public RootDialog(ILuisService luisService, IQnAMakerAIService qnaMakerAIService)
        {
            _qnaMakerAIService = qnaMakerAIService;
            _luisService = luisService;
            var waterfallSteps = new WaterfallStep[]
            {
                InitialProcess,
                FinalProcess
            };

            AddDialog(new WaterfallDialog(nameof(WaterfallDialog), waterfallSteps));
            InitialDialogId = nameof(WaterfallDialog);
        }

        private async Task<DialogTurnResult> InitialProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisService._luisRecognizer.RecognizeAsync(stepContext.Context, cancellationToken);
            return await ManageIntentions(stepContext, luisResult, cancellationToken);
        }

        private async Task<DialogTurnResult> ManageIntentions(WaterfallStepContext stepContext, Microsoft.Bot.Builder.RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var topIntent = luisResult.GetTopScoringIntent();
            switch(topIntent.intent)
            {
                case "Saludar":
                    await IntentSaludar(stepContext, luisResult, cancellationToken);
                    break;
                case "Becas":
                    await IntentBecas(stepContext, luisResult, cancellationToken);
                    break;
                case "Agradecer":
                    await IntentAgradecer(stepContext, luisResult, cancellationToken);
                    break;
                case "DatosInscripcion":
                    await IntentDatosInscripcion(stepContext, luisResult, cancellationToken);
                    break;
                    case "ofertaAcademica":
                    await IntentofertaAcademica(stepContext, luisResult, cancellationToken);
                    break;
                case "Maestrias":
                    await IntentMaestrias(stepContext, luisResult, cancellationToken);
                    break;
                case "Doctorados":
                    await IntentDoctorados(stepContext, luisResult, cancellationToken);
                    break;
                case "Contacto":
                    await IntentContacto(stepContext, luisResult, cancellationToken);
                    break;
                case "informacion":
                        await Intentinformacion(stepContext, luisResult, cancellationToken);
                    break;
                case "None":
                    await IntentNone(stepContext, luisResult, cancellationToken);
                    break;
                default:
                    break;
            }

            return await stepContext.NextAsync(cancellationToken : cancellationToken);
        }

        private async Task Intentinformacion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("¿Que tipo de información requieres saber? \n\n Te dejo algunas opciones o me puedes escribir tu pregunta, estoy para atenderte bebe", cancellationToken: cancellationToken);
            await informacion.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentContacto(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Aquí te muestro la información de contacto de los diferentes coordinadores que tengo disponible:", cancellationToken: cancellationToken);
            await contacto.ToShow(stepContext, cancellationToken);
        }
        private async Task IntentDoctorados(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Te ofrecemos los siguientes doctorados:", cancellationToken: cancellationToken);
            await doctorados.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentMaestrias(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Te ofrecemos las siguientes maestrías:", cancellationToken: cancellationToken);
            await maestrias.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentofertaAcademica(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Claro está es la oferta academica con la que contamos, tenemos Doctorados y Maestrías:", cancellationToken: cancellationToken);
            await ofertaacademica.ToShow(stepContext, cancellationToken);
        }

        #region IntentLuis

        private async Task IntentSaludar(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("¿Como te puedo ayudar?", cancellationToken: cancellationToken);
        }

        private async Task IntentAgradecer(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Estoy para servirte, me gusta ayudar.", cancellationToken: cancellationToken);
        }

        private async Task IntentBecas(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Si, es la beca de posgrado de Conacyt.", cancellationToken: cancellationToken);
        }

        private async Task IntentDatosInscripcion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("-Copia cotejada del título de licenciatura, cédula profesional, acta de examen profesional o documento oficial equivalente en Derecho o disciplinas afines al Programa a cursar." + "\r\n" +
                $"-Copia de certificado de estudios con promedio mínimo de ocho." + "\r\n" +
                $"Copia del acta de nacimiento." + "\r\n" +
                $"Dos copias del CURP(actualizado)." + "\r\n" +
                $"Curriculum Vitae con soporte documental en copia." + "\r\n" +
                $"Carta de exposición de motivos." + "\r\n" +
                $"Dos fotografías tamaño infantil de frente." + "\r\n" +
                $"Dos cartas de recomendación académica.", cancellationToken: cancellationToken);
        }

        private async Task IntentNone(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var resultQnA = await _qnaMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            var score = resultQnA.FirstOrDefault()?.Score;
            string response = resultQnA.FirstOrDefault()?.Answer;

            if(score >= 0.5)
            {
                await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
            }
            else
            {
                await stepContext.Context.SendActivityAsync("No entiendo, se más claro.", cancellationToken: cancellationToken);

            }

          
        }

        #endregion
        
        // metodo del IntentNone 
        private async Task IntentNon(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var resultQna = await _qnaMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            var score = resultQna.FirstOrDefault()?.Score;
            string response = resultQna.FirstOrDefault()?.Answer;

            if(score >= 0.5)
            {
                await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
            }
            else
            {
                await stepContext.Context.SendActivityAsync("No comprendo, lo que que quieres decir", cancellationToken: cancellationToken);
            }
        }
        private async Task<DialogTurnResult> FinalProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }
    }
}
