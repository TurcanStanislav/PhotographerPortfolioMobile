using CommunityToolkit.Mvvm.ComponentModel;
using PhotographerPortfolioMobile.Models;
using System.Collections.ObjectModel;

namespace PhotographerPortfolioMobile.ViewModels
{
    public partial class HistoryViewModel : BaseViewModel
    {
        [ObservableProperty]
        public ObservableCollection<Story> stories = new();

        public HistoryViewModel()
        {
        }
    }
}
