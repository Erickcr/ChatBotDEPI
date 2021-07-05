using DEPIBot.Common.Cards;
using DEPIBot.Common.Cards.DElectrica;
using DEPIBot.Common.Cards.MElectrica;
using DEPIBot.Common.Cards.MElectronica;
using DEPIBot.Common.Cards.MSistemas;
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
        private readonly IQnAMakerAIService _qnaMakerAIService;
        private readonly ILuisService _luisService;

        public RootDialog(IQnAMakerAIService qnaMakerAIService, ILuisService luisService)
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

        private async Task IntentNone(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var resultQnA = await _qnaMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            var score = resultQnA.FirstOrDefault()?.Score;
            string response = resultQnA.FirstOrDefault()?.Answer;

            if (score >= 0.5)
            {
                await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
            }
            else
            {
                await stepContext.Context.SendActivityAsync("No entiendo, se más claro.", cancellationToken: cancellationToken);

            }


        }


        private async Task<DialogTurnResult> FinalProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
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
                case "Profesionalizantes":
                    await IntentProfesionalizantes(stepContext, luisResult, cancellationToken);
                    break;
                case "Ciencias":
                    await IntentCiencias(stepContext, luisResult, cancellationToken);
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
                case "Convenios":
                    await IntentConvenios(stepContext, luisResult, cancellationToken);
                break;
                case "DEPI":
                    await IntentDEPI(stepContext, luisResult, cancellationToken);
                    break;
                case "None":
                    await IntentNone(stepContext, luisResult, cancellationToken);
                    break;
                case "campoaccion_MElectronica":
                    await IntentcaME(stepContext, luisResult, cancellationToken);
                    break;
                case "planestudio_MElectronica":
                    await IntentpeME(stepContext, luisResult, cancellationToken);
                    break;
                case "requiEgreso_MElectronica":
                    await IntentreME(stepContext, luisResult, cancellationToken);
                    break;
                case "requisitos_MElectronica":
                    await IntentrME(stepContext, luisResult, cancellationToken);
                    break;
                case "docum_MElectronica":
                    await IntentdME(stepContext, luisResult, cancellationToken);
                    break;
                case "campo_accionMSistemas":
                    await IntentcaMS(stepContext, luisResult, cancellationToken);
                    break;
                case "planestudio_MSistemas":
                    await IntentpeMS(stepContext, luisResult, cancellationToken);
                    break;
                case "planestudio_MElectrica":
                    await Intentpest_me(stepContext, luisResult, cancellationToken);
                    break;
                case "perfiling_MElectrica":
                    await Intentpi_me(stepContext, luisResult, cancellationToken);
                    break;
                case "perfilegreso_MElectrica":
                    await Intentpe_me(stepContext, luisResult, cancellationToken);
                    break;
                case "perfilingreso_DElectrica":
                    await Intentpi_de(stepContext, luisResult, cancellationToken);
                    break;
                case "perfilegreso_DElectrica":
                    await Intentpe_de(stepContext, luisResult, cancellationToken);
                    break;
                case "planestudio_DElectrica":
                    await Intentplan_de(stepContext, luisResult, cancellationToken);
                    break;
                default:
                    break;
            }

            return await stepContext.NextAsync(cancellationToken : cancellationToken);
        }

        private async Task Intentplan_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("", cancellationToken: cancellationToken);
            await planestudio_DE.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpe_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("", cancellationToken: cancellationToken);
            await perfilegreso_DE.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpi_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("", cancellationToken: cancellationToken);
            await perfilingreso_DE.ToShow(stepContext, cancellationToken);
        }


        #region IntentLuis

        private async Task Intentpe_me(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Perfil de egreso:", cancellationToken: cancellationToken);
            await perfil_egreso.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpi_me(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Perfil de ingreso:", cancellationToken: cancellationToken);
            await perfil_ingreso.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpest_me(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Plan de estudios:", cancellationToken: cancellationToken);
            await plan_estudio.ToShow(stepContext, cancellationToken);
        }
        private async Task IntentpeMS(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Plan de estudios:", cancellationToken: cancellationToken);
            await planestudio_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentcaMS(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Campo de acción:", cancellationToken: cancellationToken);
            await campoaccion_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentdME(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Documentación:", cancellationToken: cancellationToken);
            await doc_admin_me.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentrME(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Los requisitos de ingreso para la Maestría en Electrónica son los siguientes:", cancellationToken: cancellationToken);
            await intentrME.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentreME(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Egreso:", cancellationToken: cancellationToken);
            await requisitos_egreso.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentpeME(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("El Plan de Estudio de la Maestría en Electrónica es:", cancellationToken: cancellationToken);
            await inntentpeME.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentcaME(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Campo de acción", cancellationToken: cancellationToken);
            await campo_accion.ToShow(stepContext, cancellationToken);
        }
        private async Task Intentinformacion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("¿Que tipo de información requieres saber? \n\n Te dejo algunas opciones o me puedes escribir tu pregunta, estoy para atenderte bebe", cancellationToken: cancellationToken);
            await informacion.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentProfesionalizantes(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Te ofrecemos las siguientes Maestrías Profesionalizantes:", cancellationToken: cancellationToken);
            await Profesionalizantes.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentCiencias(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Te ofrecemos las siguientes Maestrías Ciencias:", cancellationToken: cancellationToken);
            await Ciencias.ToShow(stepContext, cancellationToken);
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
            await stepContext.Context.SendActivityAsync("Estás son las ofertas académicas con la que contamos, tenemos Doctorados y Maestrías", cancellationToken: cancellationToken);
            await ofertaacademica.ToShow(stepContext, cancellationToken);
        }

        private async Task IntentBecas(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Becas para posgrados:", cancellationToken: cancellationToken);
            await Becas.ToShow(stepContext, cancellationToken);
        }



        private async Task IntentSaludar(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("¿Como te puedo ayudar?", cancellationToken: cancellationToken);
        }
        private async Task IntentConvenios(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Los convenios que se estamos manejando son con el Consejo Nacional de Ciencia y Tecnología (CONACYT), Comisión Federal de Electricidad (CFE) y etc.", cancellationToken: cancellationToken);
        }

        private async Task IntentDEPI(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Es la División de Estudios de Posgrado e Investigación, " +
                "nuestro objetivo es planear, coordinar, controlar y evaluar los estudios de posgrado que se imparten en el Instituto Tecnológico de Morelia etc.", cancellationToken: cancellationToken);
        }

        private async Task IntentAgradecer(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Estoy para servirte, me gusta ayudar.", cancellationToken: cancellationToken);
        }

        

        private async Task IntentDatosInscripcion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("-Copia cotejada del título de licenciatura, cédula profesional, acta de examen profesional o documento oficial equivalente en Derecho o disciplinas afines al Programa a cursar." + "\r\n" +
                $"-Copia de certificado de estudios con promedio mínimo de ocho." + "\n" +
                $"Copia del acta de nacimiento." + "\n" +
                $"Dos copias del CURP(actualizado)." + "\n" +
                $"Curriculum Vitae con soporte documental en copia." + "\n" +
                $"Carta de exposición de motivos." + "\n" +
                $"Dos fotografías tamaño infantil de frente." + "\n" +
                $"Dos cartas de recomendación académica.", cancellationToken: cancellationToken);
        }
        #endregion



















        // metodo del IntentNone 
        private async Task IntentNon(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var resultQna = await _qnaMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            var score = resultQna.FirstOrDefault()?.Score;
            string response = resultQna.FirstOrDefault()?.Answer;

            if (score >= 0.5)
            {
                await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
            }
            else
            {
                await stepContext.Context.SendActivityAsync("No comprendo, lo que que quieres decir", cancellationToken: cancellationToken);
            }
        }

    }
}
