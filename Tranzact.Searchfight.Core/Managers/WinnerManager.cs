using System;
using System.Collections.Generic;
using System.Linq;
using Tranzact.Searchfight.Core.Interfaces;
using Tranzact.Searchfight.Core.Models;
using Tranzact.Searchfight.Shared.Extensions;

namespace Tranzact.Searchfight.Core.Managers
{
    public class WinnerManager : IWinnerManager
    {
        public Winner GetGrandWinner(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            Search searchWinner = searchData.GetMax(item => item.Results);
            return new Winner() { Engine = searchWinner.SearchEngine, Term = searchWinner.Term };
        }

        public IEnumerable<Winner> GetSearchEngineWinners(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count() == 0)
                throw new ArgumentException("The specified argument is invalid.", nameof(searchData));

            IEnumerable<Winner> searchEngines = searchData.GroupBy(data => data.SearchEngine,
                result => result, (searchEngine, results) => new Winner
                {
                    Engine = searchEngine,
                    Term = results.GetMax(item => item.Results).Term
                });

            return searchEngines;
        }
    }
}
