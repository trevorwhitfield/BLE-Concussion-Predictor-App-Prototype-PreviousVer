using Test_android_app.ViewModel;

namespace Test_android_app;

public partial class GameDataPage : ContentPage
{
	public GameDataPage(GameDataModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}