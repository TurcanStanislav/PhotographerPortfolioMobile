using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class AppSharingPage : ContentPage
{
	public AppSharingPage(AppSharingViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}