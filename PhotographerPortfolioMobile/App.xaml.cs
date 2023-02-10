using PhotographerPortfolioMobile.ViewModels;

namespace PhotographerPortfolioMobile;

public partial class App : Application
{
	public App(AppShellViewModel vm)
	{
		InitializeComponent();

		MainPage = new AppShell(vm);
	}
}
