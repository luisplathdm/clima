namespace clima;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

	Results results = new Results();
	void TestaLayout()
	{
		results.temp = 23;
	}
void PreencherTela()
{
	LabelTemp.Text= results.temp.ToString();
    LabelCity.Text= results.city;
	
}
}



