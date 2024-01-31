using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Services
{
    public class ChatBotService : IChatBotService
    {
        private readonly IChatQuestionRepository chatQuestionRepository;
        private readonly IChatAnswerRepository chatAnswerRepository;

        public ChatBotService(IChatQuestionRepository chatQuestionRepository, IChatAnswerRepository chatAnswerRepository)
        {
            this.chatQuestionRepository = chatQuestionRepository;
            this.chatAnswerRepository = chatAnswerRepository;
        }


        public async Task<APIResponse<ChatBotResponse>> AddChatAnswer(ChatBotAnswerRequest model)
        {
            var chatAnswer = new ChatAnswer() { QuestionId = model.QuestionId, Answer = model.Answer };

            var res = await chatAnswerRepository.AddAsync(chatAnswer);

            if (res > 0)
                return APIResponse<ChatBotResponse>.SuccessResponse(result: new ChatBotResponse(chatAnswer.Id, chatAnswer.Answer));

            return APIResponse<ChatBotResponse>.ErrorResponse();
        }

        public async Task<APIResponse<ChatBotResponse>> AddChatQuestions(ChatBotRequest model)
        {
            var chatquestion = new ChatQuestion() { Question = model.Question };

            var res = await
                chatQuestionRepository.AddAsync(chatquestion);

            if (res > 0)
                return APIResponse<ChatBotResponse>.SuccessResponse(result: new ChatBotResponse(chatquestion.Id, chatquestion.Question));

            return APIResponse<ChatBotResponse>.ErrorResponse();
        }

        public async Task<APIResponse<ChatBotAsnwerResponse>> ChatAnswer(Guid questionId)
        {
            var answer = await chatAnswerRepository.FirstOrDefaultAsync(_ => _.QuestionId == questionId);

            if (answer is null)
                return APIResponse<ChatBotAsnwerResponse>.ErrorResponse();

            return APIResponse<ChatBotAsnwerResponse>.SuccessResponse(result: new ChatBotAsnwerResponse(answer.Id, answer.Answer));
        }

        public async Task<APIResponse<IEnumerable<ChatBotResponse>>> ChatQuestions()
        {
            var qustions = await chatQuestionRepository.FilterAsync(_ => _.Show);

            return APIResponse<IEnumerable<ChatBotResponse>>.SuccessResponse(result: qustions.Select(_ => new ChatBotResponse(_.Id, _.Question)));
        }
    }
}
