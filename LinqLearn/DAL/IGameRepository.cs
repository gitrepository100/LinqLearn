using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqLearn.Models;

namespace LinqLearn.DAL
{
    public interface IGameRepository
    {
        Task<Game> Add(Game newGame);

        Task<Game> Update(Game updatedGame);


        Task Delete(int gameId);

        Task<List<Game>> GetList(Func<Game, bool> filterFunc = null, int skipCnt = 0, int takeCnt = 0 );

        Task<Game> GetById(int gameId);
    }
}
