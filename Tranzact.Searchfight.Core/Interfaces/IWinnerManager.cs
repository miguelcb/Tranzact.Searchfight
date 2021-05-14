using System.Collections.Generic;
using Tranzact.Searchfight.Core.Models;

namespace Tranzact.Searchfight.Core.Interfaces
{
    public interface IWinnerManager
    {
        /// <summary>
        /// Get an enumerable with all the winners by engine.
        /// </summary>
        /// <param name="searchData">A list with al the search results.</param>
        /// <returns>An enumerable with winners by engine.</returns>
        IEnumerable<Winner> GetSearchEngineWinners(IList<Search> searchData);

        /// <summary>
        /// Get grand winner from all the search data.
        /// </summary>
        /// <param name="searchData">A list with al the search results.</param>
        /// <returns>The grand winner information.</returns>
        Winner GetGrandWinner(IList<Search> searchData);
    }
}
