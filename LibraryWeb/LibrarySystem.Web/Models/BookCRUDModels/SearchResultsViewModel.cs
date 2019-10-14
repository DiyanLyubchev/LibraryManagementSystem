using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Web.Models
{
    public class SearchResultsViewModel : BaseViewModel
    {
        public SearchResultsViewModel()
        {
        }

        public SearchResultsViewModel(IEnumerable<SearchViewModel> searchViewModel)
        {
            this.Result = searchViewModel;
        }

        public IEnumerable<SearchViewModel> Result { get; set; } = new List<SearchViewModel>();

    }
}
