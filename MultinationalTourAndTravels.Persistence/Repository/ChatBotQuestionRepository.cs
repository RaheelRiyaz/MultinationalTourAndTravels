using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Persistence.Dapper;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class ChatBotQuestionRepository : BaseRepository<ChatQuestion>, IChatQuestionRepository
    {
        public ChatBotQuestionRepository(MultinationalTourAndTravelsDbContext dbContext) :base(dbContext)
        {
        }

        public async Task<int> DeleteQuestionAnswers(Guid questionId)
        {
            return await dbContext.ExecuteAsync("SpDeleteQuestionAnswer",new {questionId},commandType:CommandType.StoredProcedure);
        }
    }
}
