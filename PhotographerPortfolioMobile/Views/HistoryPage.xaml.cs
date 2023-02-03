using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class HistoryPage : ContentPage
{
    public HistoryPage(HistoryViewModel historyViewModel)
    {
        InitializeComponent();
        BindingContext = historyViewModel;
    }
}