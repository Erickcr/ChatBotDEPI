// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace DEPIBot
{
   
    public class DEPIBot<T> : ActivityHandler where T: Dialog
    {
        private readonly BotState _userState;
        private readonly BotState _conversationState;
        private readonly Dialog _dialog;
        
        public DEPIBot(UserState userState, ConversationState conversationState, T dialog)
        {
            _userState = userState;
            _conversationState = conversationState;
            _dialog = dialog;
        }


        protected override async Task OnConversationUpdateActivityAsync(ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(turnContext.Activity.From.Name))
                await turnContext.SendActivityAsync(MessageFactory.Text($"Hola, Bienvenido a la DEPI, Division de Estudios de Posgrado e Investigacion"), cancellationToken);

            await base.OnConversationUpdateActivityAsync(turnContext, cancellationToken);
        }
        //protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        //{
        //    foreach (var member in membersAdded)
        //    {
        //        if (member.Id != turnContext.Activity.Recipient.Id)
        //        {
        //            await turnContext.SendActivityAsync(MessageFactory.Text($"Hola, Bienvenido a la DEPI, Division de Estudios de Posgrado e Investigacion"), cancellationToken);
        //        }
        //    }
        //}


        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            //var userMessage = turnContext.Activity.Text;
            //await turnContext.SendActivityAsync($"User:{userMessage}", cancellationToken: cancellationToken );

            await _dialog.RunAsync(
                turnContext,
                _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
                cancellationToken
                );
        }
    }
}
