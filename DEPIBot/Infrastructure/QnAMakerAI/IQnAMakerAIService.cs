using Microsoft.Bot.Builder.AI.QnA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot.Infrastructure.QnAMakerAI
{
    public interface IQnAMakerAIService
    {
        QnAMaker _qnaMakerResult { get; set; }
    }

}