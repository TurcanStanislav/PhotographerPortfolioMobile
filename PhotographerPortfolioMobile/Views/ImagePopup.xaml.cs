using CommunityToolkit.Maui.Views;
using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile.Views;

public partial class ImagePopup : Popup
{
	public ImagePopup(string imagePath)
	{
		InitializeComponent();
		BindingContext = new ImagePopupViewModel { ImagePath = imagePath };
	}
}