using System;
using System.Linq.Expressions;
using LinqLearn.Models;

namespace LinqLearn.Services
{
    public class GameFilterProvider : IGameFilterProvider
    {
        public Func<Game, bool> GetFilterFunction(GameSearchSettings searchSettingsCollection)
        {
            Expression<Func<Game, bool>> filterExpression = game => true;

            //TODO: implement logic here;

            return filterExpression.Compile();
        }
    }
}
