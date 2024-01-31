using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Persistence.Repository
{
    public class ChatBotAnswerRepository : BaseRepository<ChatAnswer>, IChatAnswerRepository
    {
        public ChatBotAnswerRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
