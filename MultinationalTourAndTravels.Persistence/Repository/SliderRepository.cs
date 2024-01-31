using MultinationalTourAndTravels.Application.Abstractions.IRepository;
using MultinationalTourAndTravels.Application.RRModels;
using MultinationalTourAndTravels.Domain.Entities;
using MultinationalTourAndTravels.Domain.Enums;
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
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
    {
        private const string baseQuery = $@"SELECT S.Id,S.[Description],
                                            A.FilePath,
                                            Case 
                                            WHEN ShowSlide = 1 THEN 'True'
                                            ELSE 'False' 
                                            END AS SlideStatus
                                            FROM Sliders S
                                            INNER JOIN AppFiles A
                                            ON S.ID = A.EntityId  ";
        public SliderRepository(MultinationalTourAndTravelsDbContext dbContext) : base(dbContext) { }


        public async Task<int> ChangeSlideStatus(Guid id, ShowSlide status)
        {
            string query = $@"UPDATE Sliders SET ShowSlide = @status WHERE Id = @id";
            return await dbContext.ExecuteAsync(query, new { status ,id});
        }


        public async Task<int> DeleletSlider(Guid id)
        {
            return await dbContext.ExecuteAsync("SpDeleteSlider", new { id }, commandType: CommandType.StoredProcedure);
        }


        public async Task<IEnumerable<SliderResponse>> GetActiveSlides()
        {
            string query = $@"{baseQuery} WHERE ShowSlide = 1 ORDER BY S.CreatedOn DESC";
            return await dbContext.QueryAsync<SliderResponse>(query);
        }



        public async Task<IEnumerable<SliderResponse>> GetAllSlides()
        {
            string query = $@"{baseQuery} ORDER BY S.CreatedOn DESC";
            return await dbContext.QueryAsync<SliderResponse>(query);
        }


        public async Task<SliderResponse?> GetSlideById(Guid id)
        {
            string query = $@" {baseQuery} WHERE S.Id = @id";
            return await dbContext.FirstOrdefaultAsync<SliderResponse>(query, new { id });
        }
    }
}
