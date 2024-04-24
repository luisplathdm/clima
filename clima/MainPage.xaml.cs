using System.Net.Mime;
using System.Text.Json;

namespace clima;

public partial class MainPage : ContentPage
{
     
	const string Url="https://api.hgbrasil.com/weather42bd1065";
	public MainPage()

	{
		InitializeComponent();
		AtualizaTempo();
	}

    async void AtualizaTempo() 
	{
		try
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetAsync(Url);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				resposta = JsonSerializer.Deserialize<Resposta>(content);
			}
			PreencherTela();
		}
		catch (Exception e)	
		{
			System.Diagnostics.Debug.WriteLine(e);
		}
	}

Results results = new Results();

	
    void PreencherTela()
		{
			LabelTemp.Text= results.temp.ToString();
			LabelCity.Text= results.city;
			labelcidade.Text = results.city;
			labeldachuva.Text = results.rain.ToString();
			labeldaumidade.Text = results.humidity.ToString();
			labeldaforcadovento.Text = results.wind_speedy;
			labeldadirecaodovento.Text = results.wind_direction.ToString();
			labeldonascerdosol.Text = results.sunrise;
			labeldopordosol.Text = results.sunset;
			if ( results.currently=="chuva")
			{
			if (results.rain >= 10 )
				ImgBackground.Source = "chuva.png";
			else if (results.cloudiness >= 10)
			imgBackground.Source ="chuva.png";
			else 
				imgBackground.Source ="chuva.png";
			}
		}

}

