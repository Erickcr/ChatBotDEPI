using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace EchoBot.Infrastructure.QnAMakerAI
{
    public class QnAMakerAIService : IQnAMakerAIService
    {
        public QnAMaker _qnaMakerResult { get; set; }


        public QnAMakerAIService(IConfiguration configuration)
        {
            _qnaMakerResult = new QnAMaker(new QnAMakerEndpoint
            {
                KnowledgeBaseId = configuration["QnAMakerBaseId"],
                EndpointKey = configuration["QnAMakerKey"],
                Host = configuration["QnAMakerHostName"]
            });
        }

    }
}
