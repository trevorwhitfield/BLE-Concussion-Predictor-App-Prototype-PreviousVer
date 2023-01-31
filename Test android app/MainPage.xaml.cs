using Test_android_app.ViewModel;

namespace Test_android_app;

public partial class MainPage : ContentPage
{

	public MainPage(MainViewModel vm)
	{
		InitializeComponent(); //If something is not recognized, you made a typo loading libraries somewhere
		BindingContext = vm;
	}

}

