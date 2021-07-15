using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqLearn.Models;

namespace LinqLearn.DAL
{
    public class InMemoryGamesRepository : IGameRepository
    {
        private static readonly List<Game> Games = new();

        public Task<Game> Add(Game newGame)
        {
            var newId = Games.Any() ? Games.Max(x => x.Id) + 1 : 1;
            newGame.Id = newId;

            Games.Add(newGame);

            return Task.FromResult(newGame);
        }

        public Task<Game> Update(Game updatedGame)
        {
            var existingGame = Games.FirstOrDefault(g => g.Id == updatedGame.Id);

            if (existingGame == null)
            {
                throw new KeyNotFoundException($"Game with id {updatedGame.Id} not found");
            }

            existingGame.Name = updatedGame.Name;
            existingGame.Genres = updatedGame.Genres;
            existingGame.Price = updatedGame.Price;

            return Task.FromResult(existingGame);
        }

        public Task Delete(int gameId)
        {
            var existingGame = Games.FirstOrDefault(g => g.Id == gameId);

            if (existingGame == null)
            {
                throw new KeyNotFoundException($"Game with id {gameId} not found");
            }

            Games.Remove(existingGame);

            return Task.CompletedTask;
        }

        public Task<List<Game>> GetList(Func<Game, bool> filterFunc = null, int skipCnt = 0, int takeCnt = 0)
        {
            var source = Games.AsQueryable();

            if (filterFunc != null)
            {
                source = source.Where(x => filterFunc(x));
            }

            if (skipCnt != 0)
            {
                source = source.Skip(skipCnt);
            }

            if (takeCnt != 0)
            {
                source = source.Take(takeCnt);
            }

            var games = source.ToList();

            return Task.FromResult(games);
        }

        public Task<Game> GetById(int gameId)
        {
            var existingGame = Games.FirstOrDefault(g => g.Id == gameId);
            return Task.FromResult(existingGame);
        }
    }
}
