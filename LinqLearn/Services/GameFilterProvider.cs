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

            Expression<Func<Game, bool>> filterExpression = game => true;

            Expression<Func<Game, bool>> newExpression;

            if (searchSettingsCollection.MinPrice is not null)
            {
                newExpression = game => game.Price >= searchSettingsCollection.MinPrice;
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }

            if (searchSettingsCollection.MaxPrice is not null)
            {
                newExpression = game => game.Price <= searchSettingsCollection.MinPrice;
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }

            if (searchSettingsCollection.Name is not null)
            {
                newExpression = game => game.Name.StartsWith(searchSettingsCollection.Name);
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }

            if (searchSettingsCollection.Genres.Count > 0)
            { 
                newExpression = game => game.Genres.All(genre => searchSettingsCollection.Genres.Contains(genre));
                filterExpression = ExpressionCombiner.And(filterExpression, newExpression);
            }
                       
            return filterExpression.Compile();
        }
    }
}
