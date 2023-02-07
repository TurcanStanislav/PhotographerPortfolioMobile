using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class FavoriteStoriesPage : ContentPage
{
	public FavoriteStoriesPage(FavoriteStoriesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}