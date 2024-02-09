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
                return APIResponse<ChatBotResponse>.SuccessResponse(result: new ChatBotResponse(chatAnswer.Id, chatAnswer.Answer, null));

            return APIResponse<ChatBotResponse>.ErrorResponse();
        }

        public async Task<APIResponse<ChatBotResponse>> AddChatQuestions(ChatBotRequest model)
        {
            var chatquestion = new ChatQuestion() { Question = model.Question };

            var res = await
                chatQuestionRepository.AddAsync(chatquestion);

            if (res > 0)
                return APIResponse<ChatBotResponse>.SuccessResponse(result: new ChatBotResponse(chatquestion.Id, chatquestion.Question,chatquestion.Show));

            return APIResponse<ChatBotResponse>.ErrorResponse();
        }

        public async Task<APIResponse<IEnumerable<ChatBotAsnwerResponse>>> ChatAnswer(Guid questionId)
        {
            var answers = (await chatAnswerRepository.FilterAsync(_ => _.QuestionId == questionId)).OrderBy(_=>_.CreatedOn);

            if (!answers.Any())
                return APIResponse<IEnumerable<ChatBotAsnwerResponse>>.ErrorResponse();

            return APIResponse<IEnumerable<ChatBotAsnwerResponse>>.SuccessResponse(result: answers.Select(_=>new ChatBotAsnwerResponse(_.Id,_.Answer)));
        }

        public async Task<APIResponse<IEnumerable<ChatBotResponse>>> AllChatQuestions()
        {
            var qustions = (await chatQuestionRepository.GetAllAsync()).OrderBy(_=>_.CreatedOn);


            return APIResponse<IEnumerable<ChatBotResponse>>.SuccessResponse(result: qustions.Select(_ => new ChatBotResponse(_.Id, _.Question,_.Show)));
        }

        public async Task<APIResponse<IEnumerable<ChatBotResponse>>> ActiveChatQuestions()
        {
            var qustions = (await chatQuestionRepository.FilterAsync(_ => _.Show)).OrderBy(_=>_.CreatedOn);

            return APIResponse<IEnumerable<ChatBotResponse>>.SuccessResponse(result: qustions.Select(_ => new ChatBotResponse(_.Id, _.Question,_.Show)));

        }

        public async Task<APIResponse<int>> DeleteQuestionAsnwers(Guid QuestionId)
        {
            var res = await chatQuestionRepository.DeleteAsync(QuestionId);
            var answers = await chatAnswerRepository.FilterAsync(_ => _.QuestionId== QuestionId);

            await chatAnswerRepository.DeleteRangeAsync(answers);

            if (res > 0)
                return APIResponse<int>.SuccessResponse(message: "Question answers removed from chatbot");


            return APIResponse<int>.ErrorResponse();
        }


        public async Task<APIResponse<int>> ToggleQuestionStatus(UpdateQuestionStatus model)
        {
            var question = await chatQuestionRepository.GetByIdAsync(model.Id);

            if (question is null)
                return APIResponse<int>.ErrorResponse();

            question.Show = !question.Show;

            var res = await chatQuestionRepository.UpdateAsync(question);

            if (res > 0)
                return APIResponse<int>.SuccessResponse("Status updated successfully", result: res);


            return APIResponse<int>.ErrorResponse();
        }
    }
}
