using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.RRModels
{
    public record ChatBotRequest(string Question);
    public record ChatBotResponse(Guid Id,string Question);
    public record ChatBotAnswerRequest(Guid QuestionId,string Answer);
    public record ChatBotAsnwerResponse(Guid Id,string Answer);
}
