using DEPIBot.Common.Cards;
using DEPIBot.Common.Cards.DElectrica;
using DEPIBot.Common.Cards.MElectrica;
using DEPIBot.Common.Cards.MElectronica;
using DEPIBot.Common.Cards.MSistemas;
using EchoBot.Infrastructure;
using EchoBot.Infrastructure.QnAMakerAI;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DEPIBot.Dialogs
{
    public class RootDialog : ComponentDialog
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

        

        private async Task<DialogTurnResult> InitialProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisService._luisRecognizer.RecognizeAsync(stepContext.Context, cancellationToken);
            return await ManageIntentions(stepContext, luisResult, cancellationToken);
        }

        private async Task<DialogTurnResult> FinalProcess(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
        }

        private async Task<DialogTurnResult> ManageIntentions(WaterfallStepContext stepContext, Microsoft.Bot.Builder.RecognizerResult luisResult, CancellationToken cancellationToken)
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
                var topIntent = luisResult.GetTopScoringIntent();
                switch (topIntent.intent)
                {
                    //case "Saludar":
                    //    await IntentSaludar(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Becas":
                    //    await IntentBecas(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Agradecer":
                    //    await IntentAgradecer(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "ofertaAcademica":
                    //    await IntentofertaAcademica(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Maestrias":
                    //    await IntentMaestrias(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Profesionalizantes":
                    //    await IntentProfesionalizantes(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Ciencias":
                    //    await IntentCiencias(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Doctorados":
                    //    await IntentDoctorados(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Contacto":
                    //    await IntentContacto(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "informacion":
                    //    await Intentinformacion(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "Convenios":
                    //    await IntentConvenios(stepContext, luisResult, cancellationToken);
                    //    break;
                    //case "DEPI":
                    //    await IntentDEPI(stepContext, luisResult, cancellationToken);
                    //    break;
                    case "None":
                        await IntentNone(stepContext, luisResult, cancellationToken);
                        break;
                        //case "campoaccion_MElectronica":
                        //    await IntentcaME(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "planestudio_MElectronica":
                        //    await IntentpeME(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "requiEgreso_MElectronica":
                        //    await IntentreME(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "requisitos_MElectronica":
                        //    await IntentrME(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "docum_MElectronica":
                        //    await IntentdME(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "campo_accionMSistemas":
                        //    await IntentcaMS(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "planestudio_MSistemas":
                        //    await IntentpeMS(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "planestudio_MElectrica":
                        //    await Intentpest_me(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfiling_MElectrica":
                        //    await Intentpi_me(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfilegreso_MElectrica":
                        //    await Intentpe_me(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfilingreso_DElectrica":
                        //    await Intentpi_de(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfilegreso_DElectrica":
                        //    await Intentpe_de(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "planestudio_DElectrica":
                        //    await Intentplan_de(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "mi_nombre":
                        //    await Intentnombre(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "costo_examenadmin":
                        //    await Intentcosto_examen(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "hacer_examenadmin":
                        //    await Intenthacer_examen(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "fechas_titulacion":
                        //    await Intentfehca_titulacion(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "titulo_cedula":
                        //    await Intenttyc(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "puntos_ingles":
                        //    await Intentpuntos_ingles(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "sobre_imss":
                        //    await Intentimss(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "tener_titulo":
                        //    await Intenttener_titulo(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "pnpc":
                        //    await Intentpnpc(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "organismos":
                        //    await Intentorg(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivos_particulares_DElectrica":
                        //    await Intentobj_p_de(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivo_DElectrica":
                        //    await Intentobj_de(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "examen_Grado":
                        //    await Intentexa_g(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivos_particulares_MElectrica":
                        //    await Intentobj_p_me(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivo_MElectrica":
                        //    await Intentobj_me(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfil_E_MSistemas":
                        //    await Intentpe_ms(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfil_I_MSistemas":
                        //    await Intentpi_ms(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivo_MSistemas":
                        //    await Intentobj_ms(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "beca_MElectronica":
                        //    await Intentbeca_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "lG_AConocimiento_MS":
                        //    await Intentlg_ac_ms(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivos_particulares_MElectronica":
                        //    await Intentobj_p_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "objetivo_MElectronica":
                        //    await Intentobj_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "clave_MElectronica":
                        //    await Intentclave_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "perfilegreso_MElectronica":
                        //    await Intentpi_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "lG_AConocimiento_MELE":
                        //    await Intentlg_ac_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "inf_MElectronica":
                        //    await Intentinf_mele(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "dif_cyp":
                        //    await Intentcyp(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "proceso_inscripcion":
                        //    await Intentpinscripcion(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "ocupo_ingles":
                        //    await Intentoingles(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "p_profesionalizante":
                        //    await Intentprofesio(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "p_ciencias":
                        //    await Intentciencias(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "fechas_ingreso":
                        //    await Intentfehcas_ing(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "contacto_tesis":
                        //    await Intentcontacto_tesis(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "admin_desarr_proyectos":
                        //    await Intentuno(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "cedula":
                        //    await Intentdos(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "grado":
                        //    await Intenttres(stepContext, luisResult, cancellationToken);
                        //    break;
                        //case "tesis":
                        //    await Intentcuatro(stepContext, luisResult, cancellationToken);
                        //    break; 
                        //default:
                        //    break;
                }
            }
                return await stepContext.NextAsync(cancellationToken: cancellationToken);
            
        }

        //private async Task Intentcuatro(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await tesis.ToShow(stepContext, cancellationToken);
        //}

        private async Task Intenttres(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await grado.ToShow(stepContext, cancellationToken); 
        }

        private async Task Intentdos(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await cedula.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentuno(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await admin_proyectos.ToShow(stepContext, cancellationToken);
        }


        #region IntentLuis

        //private async Task Intentcontacto_tesis(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await contacto_tesis.ToShow(stepContext, cancellationToken);
        //}

        //private async Task Intentfehcas_ing(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Las fechas para el próximo semestre ago-dic 2021 son: \n\n dd-mm-aaaa al dd-mm-aaaa.", cancellationToken: cancellationToken);

        //}

        //private async Task Intentciencias(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Son los posgrados que pertenecen al Programa Nacional de Posgrados de Calidad y tiene como objetivo el formar recursos humanos en Ciencias con un alto nivel académico, con habilidad suficiente para proponer proyectos de investigación original de manera independiente.", cancellationToken: cancellationToken);

        //}

        //private async Task Intentprofesio(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Son los posgrados que tiene como campo de estudio una disciplina profesional y se diferencia del doctorado en investigación etc.", cancellationToken: cancellationToken);

        //}

        //private async Task Intentoingles(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Si", cancellationToken: cancellationToken);

        //}

        private async Task Intentpinscripcion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await proceso_insc.ToShow(stepContext, cancellationToken);
        }

        //private async Task Intentcyp(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Su diferencia es que en Ciencias enfatizarán la investigación y la docencia, mientras los Profesionalizantes enfatizarán el desarrollo de modelos o pautas apropiadas a la consultoría y la prestación de servicios.", cancellationToken: cancellationToken);

        //}
        //private async Task Intentorg(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Se incorporan la PRODEP, CONACyT y SICDET.", cancellationToken: cancellationToken);
        //}


        //private async Task Intenttener_titulo(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Si, es un requisito obligatorio", cancellationToken: cancellationToken);
        //}

        private async Task Intentimss(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Es la hoja rosa que te dan en tu lugar de trabajo o la puedes obtener de la siguiente liga: https://www.gob.mx/afiliatealimss ", cancellationToken: cancellationToken);
        }

        //private async Task Intentpuntos_ingles(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Debes tener 420 puntos de TOEFL o su equivalente en escala europea (B1)", cancellationToken: cancellationToken);
        //}

        private async Task Intenttyc(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Solicita una constancia de título en trámite en el área de servicios escolares de tu institución.", cancellationToken: cancellationToken);
        }

        //private async Task Intentfehca_titulacion(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Para determinar una fecha de titulación se ponen en acuerdo el alumno, profesor y los sinodales.", cancellationToken: cancellationToken);
        //}

        //private async Task Intenthacer_examen(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Es obligatorio hacer el examen de admisión, pero para mayor información puedes ponerte en contacto con el coordinador correspondiente, recuerda que cuento con los contactos de cada uno de ellos.", cancellationToken: cancellationToken);
        //}

        //private async Task Intentcosto_examen(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Para el semestre Agosto-Diciembre 2021 tendrá un costo de $10,000.00", cancellationToken: cancellationToken);
        //}
        //private async Task Intentnombre(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Que tal, mi nomre es Lulú", cancellationToken: cancellationToken);
        //}

        private async Task Intentplan_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await planestudio_DE.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpe_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await perfilegreso_DE.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpi_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await perfilingreso_DE.ToShow(stepContext, cancellationToken);
        }

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

        private async Task Intentpe_ms(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("El perfil de egreso de la Maestría en Sistemas Computacionales:", cancellationToken: cancellationToken);
            await perfil_egreso_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpi_ms(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("El perfil de ingreso a la Maestría en Ingeniería en Sistemas Computacionales es:", cancellationToken: cancellationToken);
            await perfil_ingreso_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentobj_ms(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Nuestros objetivos y metas son:", cancellationToken: cancellationToken);
            await objetivo_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentbeca_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Este programa de maestría cuenta con el reconocimiento de:", cancellationToken: cancellationToken);
            await beca_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentlg_ac_ms(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Tiene dos líneas de generación y aplicación del Conocimiento", cancellationToken: cancellationToken);
            await lg_ac_ms.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentobj_p_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await obj_p_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentobj_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await obj_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentclave_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await clave_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentpi_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await pi_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentlg_ac_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await lg_ac_mele.ToShow(stepContext, cancellationToken);
        }

        private async Task Intentinf_mele(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await inf_mele.ToShow(stepContext, cancellationToken);
        }








        //private async Task IntentSaludar(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("¿Como te puedo ayudar?", cancellationToken: cancellationToken);
        //}
        //private async Task IntentConvenios(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Los convenios que se estamos manejando son con el Consejo Nacional de Ciencia y Tecnología (CONACYT), Comisión Federal de Electricidad (CFE) y etc.", cancellationToken: cancellationToken);
        //}

        //private async Task IntentDEPI(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Es la División de Estudios de Posgrado e Investigación, " +
        //        "nuestro objetivo es planear, coordinar, controlar y evaluar los estudios de posgrado que se imparten en el Instituto Tecnológico de Morelia etc.", cancellationToken: cancellationToken);
        //}

        //private async Task IntentAgradecer(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Estoy para servirte, me gusta ayudar.", cancellationToken: cancellationToken);
        //}

        //private async Task Intentobj_p_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Nuestros objetivos particulares siguientes:" + "\r\n" +
        //        "• Formar profesionales capaces de dirigir e incorporarse a participar en trabajos de investigación científica y desarrollo tecnológico, aplicando sus conocimientos y las metodologías" +
        //        " necesarias de forma original e innovadora, contribuyendo a la generación de nuevos conocimientos y tecnologías." + "\r\n" +
        //        "• Preparar a sus egresados en la detección y análisis de problemas tecnológicos, innovando, mejorando y adaptando tecnologías en el desarrollo de proyectos de investigación." + "\r\n" +
        //        "• Preparar a los egresados para que adquieran un perfil de un profesionista íntegro y con alto sentido de compromiso con su profesión y la sociedad." + "\r\n" +
        //        "• Preparar a sus egresados para realizar actividades de docencia e investigación de calidad a nivel licenciatura y posgrado.", cancellationToken: cancellationToken);
        //}

        //private async Task Intentobj_de(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Nuestro objetivo del Doctorado en Ciencias en Ingeniería Eléctrica es formar recursos humanos de alto nivel" +
        //        " académico con conocimientos de frontera en el área de ingeniería eléctrica, capaces de realizar actividades de investigación científica" +
        //        " y/o desarrollo tecnológico de manera original.", cancellationToken: cancellationToken);
        //}

        private async Task Intentexa_g(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await stepContext.Context.SendActivityAsync("Es el examen en dónde presentarás los resultados de tu investigación con evidencia fundamentada ante el comité de revisión.", cancellationToken: cancellationToken);
        }

        //private async Task Intentobj_p_me(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("El plan de estudios de la Maestría en Ciencias tienen los siguientes objetivos particulares:" + "\r\n" +
        //        "• Formar profesionales capaces de incorporarse y participar en trabajos de investigación científica y desarrollo tecnológico aplicando sus conocimientos" +
        //        " y las metodologías necesarias, de forma original e innovadora." + "\r\n" +
        //        "• Preparar a sus egresados en la detección, análisis y solución de problemas, innovando, mejorando y adaptando tecnologías de frontera en procesos productivos." + "\r\n" +
        //        "• Preparar a los egresados para que adquieran un perfil de un profesionista íntegro, con alto sentido de compromiso con su profesión y la sociedad." + "\r\n" +
        //        "• Preparar recursos humanos para realizar actividades de docencia a nivel licenciatura y posgrado." +
        //        "• Preparar a sus egresados para la continuación de estudios de doctorado", cancellationToken: cancellationToken);
        //}

        //private async Task Intentobj_me(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        //{
        //    await stepContext.Context.SendActivityAsync("Nuestro objetivo en la Maestría en Eléctrica es formar recursos humanos de alto nivel académico con una formación profesional sólida, científica y tecnológica" +
        //        " con conocimientos de frontera en el área de ingeniería eléctrica, orientados a las actividades de investigación," +
        //        " desarrollo tecnológico y docencia tanto en el sector público como en el sector privado", cancellationToken: cancellationToken);
        //}


        #endregion


        private async Task IntentNone(WaterfallStepContext stepContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            //var resultQnA = await _qnaMakerAIService._qnaMakerResult.GetAnswersAsync(stepContext.Context);

            //var score = resultQnA.FirstOrDefault()?.Score;
            //string response = resultQnA.FirstOrDefault()?.Answer;

            //if (score >= 0.5)
            //{
            //    await stepContext.Context.SendActivityAsync(response, cancellationToken: cancellationToken);
            //}
            //else
            //{
                await stepContext.Context.SendActivityAsync("No entiendo, se más claro.", cancellationToken: cancellationToken);

            //}


        }

    }
}
    
