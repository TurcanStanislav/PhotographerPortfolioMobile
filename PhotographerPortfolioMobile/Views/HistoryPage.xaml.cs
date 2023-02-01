using PhotographerPortfolioMobile.Services.Interfaces;
using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class HistoryPage : ContentPage
{
    private readonly HistoryViewModel HistoryViewModel;
    private readonly IHistoryService HistoryService;

    public HistoryPage(HistoryViewModel historyViewModel, IHistoryService historyService)
    {
        InitializeComponent();
        BindingContext = historyViewModel;
        HistoryViewModel = historyViewModel;
        HistoryService = historyService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (HistoryViewModel.Stories.Count == 0)
            HistoryViewModel.Stories = await HistoryService.GetStoriesByIds();
    }
}