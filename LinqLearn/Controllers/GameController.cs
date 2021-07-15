using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinqLearn.DAL;
using LinqLearn.Models;
using LinqLearn.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinqLearn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository _gameRepository;
        private readonly IGameFilterProvider _filterProvider;

        public GamesController(IGameRepository gameRepository, IGameFilterProvider filterProvider)
        {
            _gameRepository = gameRepository;
            _filterProvider = filterProvider;
        }

        [HttpPost]
        [Route("search")]
        public async Task<IActionResult> SearchGames([FromBody] GameSearchSettings searchSettings)
        {
            var filterFunction = _filterProvider.GetFilterFunction(searchSettings);

            var games = await _gameRepository.GetList(filterFunction, searchSettings.Skip, searchSettings.Take);

            return Ok(games);
        }

        [HttpGet]
        public async Task<IActionResult> GetGames(int skip, int take)
        {
            var games = await _gameRepository.GetList(skipCnt: skip, takeCnt: take);

            return Ok(games);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetGame(int id)
        {
            var game = await _gameRepository.GetById(id);

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] Game game)
        {
            await _gameRepository.Add(game);
            var uri = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}/{game.Id}");
            return Created(uri, game);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] Game updatedGame)
        {
            try
            {
                updatedGame.Id = id;
                var game = await _gameRepository.Update(updatedGame);

                return Ok(game);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            try
            {
                await _gameRepository.Delete(id);
            }
            catch (KeyNotFoundException)
            { }

            return NoContent();
        }
    }
}
