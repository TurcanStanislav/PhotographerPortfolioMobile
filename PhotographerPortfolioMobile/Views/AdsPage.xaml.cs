using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class AdsPage : ContentPage
{
	public AdsPage(AdsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}