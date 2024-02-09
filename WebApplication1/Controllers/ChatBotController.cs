using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultinationalTourAndTravels.Application;
using MultinationalTourAndTravels.Application.Abstractions.IServices;
using MultinationalTourAndTravels.Application.RRModels;

namespace MultinationalTourAndTravels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotService chatBotService;

        public ChatBotController(IChatBotService chatBotService)
        {
            this.chatBotService = chatBotService;
        }


        [HttpGet("active-questions")]
        public async Task<APIResponse<IEnumerable<ChatBotResponse>>> ActiveChatQuestions()=>
            await chatBotService.ActiveChatQuestions();



        [HttpGet("all-questions")]
        public async Task<APIResponse<IEnumerable<ChatBotResponse>>> AllChatQuestions() =>
           await chatBotService.AllChatQuestions();



        [HttpPost("chat-question")]
        public async Task<APIResponse<ChatBotResponse>> AddChatQuestions(ChatBotRequest model)=>
            await chatBotService.AddChatQuestions(model);



        [HttpPost("answer")]
        public async Task<APIResponse<ChatBotResponse>> AddChatAnswer(ChatBotAnswerRequest model) =>
            await chatBotService.AddChatAnswer(model);



        [HttpGet("answer/{questionId:guid}")]
        public async Task<APIResponse<IEnumerable<ChatBotAsnwerResponse>>> ChatAnswer(Guid questionId)=>
            await chatBotService.ChatAnswer(questionId);



        [HttpDelete("question-answers/{questionId:guid}")]
        public async Task<APIResponse<int>> DeleteQuestionAsnwers(Guid questionId) =>
            await chatBotService.DeleteQuestionAsnwers(questionId);



        [HttpPut("status")]
        public async Task<APIResponse<int>> ToggleQuestionStatus(UpdateQuestionStatus model) =>
            await chatBotService.ToggleQuestionStatus(model);

    }
}
