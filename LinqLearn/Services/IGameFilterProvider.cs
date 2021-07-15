using System;
using LinqLearn.Models;

namespace LinqLearn.Services
{
    public interface IGameFilterProvider
    {
        Func<Game, bool> GetFilterFunction(GameSearchSettings searchSettingsCollection);
    }
}
