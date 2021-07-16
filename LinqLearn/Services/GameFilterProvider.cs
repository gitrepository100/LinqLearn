using System;
using System.Linq;
using System.Linq.Expressions;
using LinqLearn.Models;

namespace LinqLearn.Services
{
    public class GameFilterProvider : IGameFilterProvider
    {
        public Func<Game, bool> GetFilterFunction(GameSearchSettings searchSettingsCollection)
        {
            //TODO: implement logic here;

            Expression<Func<Game, bool>> filterExpression = game => game.Price >= searchSettingsCollection.MinPrice;

            Expression<Func<Game, bool>> newExpression = game => game.Price <= searchSettingsCollection.MaxPrice;

            if (searchSettingsCollection.MaxPrice != 0)
            {
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }

            newExpression = game => game.Name.StartsWith(searchSettingsCollection.Name);

            if (searchSettingsCollection.Name != "string")
            {
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }

            newExpression = game => game.Genres.All(genre => searchSettingsCollection.Genres.Contains(genre));

            if (searchSettingsCollection.Genres.ElementAt(0) != "string" )
            {
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }
                       
            return filterExpression.Compile();
        }
    }
}
