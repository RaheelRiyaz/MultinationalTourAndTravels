using MultinationalTourAndTravels.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultinationalTourAndTravels.Application.Abstractions.IRepository
{
    public interface IChatQuestionRepository : IBaseRepository<ChatQuestion>
    {
        Task<int> DeleteQuestionAnswers(Guid questionId);
    }
}
