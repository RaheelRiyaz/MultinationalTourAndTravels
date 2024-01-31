using MultinationalTourAndTravels.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IServices
{
    public interface IChatBotService
    {
        Task<APIResponse<IEnumerable<ChatBotResponse>>> ChatQuestions();
        Task<APIResponse<ChatBotResponse>> AddChatQuestions(ChatBotRequest model);
        Task<APIResponse<ChatBotResponse>> AddChatAnswer(ChatBotAnswerRequest model);
        Task<APIResponse<ChatBotAsnwerResponse>> ChatAnswer(Guid QuestionId);
    }
}
