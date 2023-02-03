using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class StoryDetailsPage : ContentPage
{
	public StoryDetailsPage(StoryDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}