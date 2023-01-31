namespace Test_android_app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(GameDataPage), typeof(GameDataPage));
	}
}
